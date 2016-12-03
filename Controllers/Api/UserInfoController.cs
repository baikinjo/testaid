using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondAid.Data;
using Microsoft.AspNetCore.Identity;
using SecondAid.Models;
using SecondAid.Models.AccountViewModels;

namespace SecondAid.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/UserInfo")]
    public class UserInfoController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserInfoController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return new UserInfoViewModel
                {
                    ResponseCode = 400
                };
            }

            var user = await _userManager.FindByIdAsync(userId);

            return new UserInfoViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Gender = user.Gender,
                PersonalHealthNumber = user.PersonalHealthNumber,
                AddressStreet = user.AddressStreet,
                AddressPostalCode = user.AddressPostalCode,
                AddressCity = user.AddressCity,
                AddressCountry = user.AddressCountry,
                AddressProvince = user.AddressProvince,
                ResponseCode = 200
            };
        }

    }
}