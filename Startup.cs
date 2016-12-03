using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using SecondAid.Models;
using OpenIddict;
using CryptoHelper;
using System.Linq;
using SecondAid.Data;
using SecondAid.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace SecondAid
{
    public class Startup
    {
        //private const string SecretKey = "needtogetthisfromenvironment";
        //private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment()) {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
//                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddOptions();

            // Add framework services.
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add framework services.
            var connection = Configuration["Data:DefaultConnection:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            /* Disabled on Nov 15, 2016 by Medhat. Replaced by following block
            services.AddOpenIddict<ApplicationUser, ApplicationDbContext>()
                .EnableAuthorizationEndpoint("/connect/authorize")
                .EnableTokenEndpoint("/connect/token")
                .EnableLogoutEndpoint("/connect/logout")

                .AllowAuthorizationCodeFlow()
                .AllowPasswordFlow()

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement()

                .AddEphemeralSigningKey();
            */

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationDbContext>()
                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                .AddMvcBinders()

                // Enable the token endpoint (required to use the password flow).
                .EnableTokenEndpoint("/connect/token")

                // Allow client applications to use the grant_type=password flow.
                .AllowPasswordFlow()

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement()

                // Register a new ephemeral key, that is discarded when the application
                // shuts down. Tokens signed using this key are automatically invalidated.
                // This method should only be used during development.
                .AddEphemeralSigningKey();

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            //services.AddCors();
            // services.AddCors();

            services.AddScoped<LanguageActionFilter>();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var supportedCultures = new List<CultureInfo>
                        {
                            new CultureInfo("en-US"),
                            new CultureInfo("en-AU"),
                            new CultureInfo("en-GB"),
                            new CultureInfo("en"),
                            new CultureInfo("es-ES"),
                            new CultureInfo("es-MX"),
                            new CultureInfo("es"),
                            new CultureInfo("de-CH"),
                            new CultureInfo("fr-FR"),
                            new CultureInfo("fr-CH"),
                            new CultureInfo("fr"),
                            new CultureInfo("it-CH")
                        };

                    options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                });


            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationDbContext>()
                // Enable the token endpoint (required to use the password flow).
                .EnableAuthorizationEndpoint("/connect/authorize")
                .EnableTokenEndpoint("/connect/token")
                .EnableLogoutEndpoint("/connect/logout")


                // Allow client applications to use the code flow.
                .AllowAuthorizationCodeFlow()

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement()

                // Register a new ephemeral key, that is discarded when the application
                // shuts down. Tokens signed using this key are automatically invalidated.
                // This method should only be used during development.
                .AddEphemeralSigningKey();

            services.AddSwaggerGen();

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ApplicationDbContext applicationDbContext
        )
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseOAuthValidation();

            app.UseOpenIddict();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            //app.UseMvc(routes =>
            //{
            //    // add the new route here.
            //    routes.MapRoute(name: "areaRoute",
            //        template: "{area:exists}/{controller}/{action}",
            //        defaults: new { controller = "Home", action = "Index" });

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvcWithDefaultRoute();
            
            //applicationDbContext.Database.Migrate();

            SecondAid.Data.Seed.SeedData.Initialize(applicationDbContext);
            SecondAid.Data.Seed.Users.UserRoleSeedData.SeedUsersAndRoles(app);

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)

            using (var context = new ApplicationDbContext(
                app.ApplicationServices.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) {
                context.Database.EnsureCreated();

                if (!context.Applications.Any()) {
                    context.Applications.Add(new OpenIddictApplication
                    {
                        // Assign a unique identifier to your client app:
                        Id = "48BF1BC3-CE01-4787-BBF2-0426EAD21342",
                        ClientId = "TestCoreClient",

                        // Assign a display named used in the consent form page:
                        DisplayName = "MVC Core client application",

                        // Register the appropriate redirect_uri and post_logout_redirect_uri:
                        RedirectUri = "http://localhost:61810/signin-oidc",
                        LogoutRedirectUri = "http://localhost:61810/",

                        // Generate a new derived key from the client secret:
                        ClientSecret = Crypto.HashPassword("secret_secret_secret"),

                        // Note: use "public" for JS/mobile/desktop applications
                        // and "confidential" for server-side applications.
                        Type = OpenIddictConstants.ClientTypes.Confidential
                    });

                    // To test this sample with Postman, use the following settings:
                    //
                    // * Authorization URL: http://localhost:61810/connect/authorize
                    // * Access token URL: http://localhost:61810/connect/token
                    // * Client ID: postman
                    // * Client secret: [blank] (not used with public clients)
                    // * Scope: openid email profile roles
                    // * Grant type: authorization code
                    // * Request access token locally: yes
                    context.Applications.Add(new OpenIddictApplication
                    {
                        ClientId = "postman",
                        DisplayName = "Postman",
                        RedirectUri = "https://www.getpostman.com/oauth2/callback",
                        Type = OpenIddictConstants.ClientTypes.Public
                    });

                    context.SaveChanges();
                }

                app.UseSwagger();

                app.UseSwaggerUi();

                app.UseCors("SiteCorsPolicy");
            }

        }
    }
}
