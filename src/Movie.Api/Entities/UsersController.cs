using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movie.Api.Entities;
using Movie.Api.Errors;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }
       

        [HttpPost]
        public UserDto Login(string email, string password)
        {
            UserDto toReturn = _userService.GetUserIfCredentialsAreValid(email, password);
            if (toReturn == null)
                throw new UserFriendlyException("The email and/or password are incorrect");
            return toReturn;
        }
    }
}
