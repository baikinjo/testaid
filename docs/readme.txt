To start the project:
	dotnet restore
	dotnet build
	dotnet ef migrations add Migration01 --output-dir Data/Migrations
	dotnet ef database update
	dotnet run

EF
	dotnet ef migrations add InitialHealthSchema --context ApplicationDbContext --output-dir Data/Migrations
	dotnet ef database update --context ApplicationDbContext

https://docs.asp.net/en/latest/publishing/azure-continuous-deployment.html

When deploying I had to:
	separately create a sqlazure database
	obtain the connection string
	add connection string to web app
	add the connectionstring to appsettings in visual studio 
	then apply migrations from client machine

This is ensuring files in .gitignore are not found in the repository
	http://stackoverflow.com/questions/1139762/ignore-files-that-have-already-been-committed-to-a-git-repository

Localization
	https://damienbod.com/2015/10/21/asp-net-5-mvc-6-localization/
	https://docs.asp.net/en/latest/fundamentals/localization.html
	https://www.jeffogata.com/asp-net-core-localization-culture/
	***	https://www.jeffogata.com/asp-net-core-localization-strings/
	*** http://www.codeproject.com/Articles/1081513/Localization-Extensibility-in-ASP-NET-Core
	http://www.martinwilley.com/net/asp/core/localization.html
	** https://damienbod.com/2015/10/24/using-dataannotations-and-localization-in-asp-net-5-mvc-6/
	Example: https://github.com/aspnet/Mvc/tree/d06dcbc9962a2a70b92e87e721aa63fb1749d11e/test/WebSites/LocalizationWebSite
	http://pratikvasani.github.io/archive/2015/12/25/MVC-6-localization-how-to/
	http://stackoverflow.com/questions/35540893/localization-and-internationalization-for-data-model-annotations-in-asp-net-5-mv/35554277

Areas
	http://timjames.me/blog/2014/12/13/mvc-areas-with-vnext/

Authentication:
	Token Authentication in ASP.NET Core - Stormpath User Identity API
		https://stormpath.com/blog/token-authentication-asp-net-core
	GitHub: https://github.com/nbarbettini/SimpleTokenProvider

	https://goblincoding.com/2016/07/03/issuing-and-authenticating-jwt-tokens-in-asp-net-core-webapi-part-i/

	https://github.com/openiddict/openiddict-core

Example of OpenIdDict: http://overengineer.net/Using-OpenIddict-to-easily-add-token-authentication-to-your-.NET-web-apps