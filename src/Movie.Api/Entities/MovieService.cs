using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.Entities
{

    public class MovieService : IService
    {
        private UserService _userService;
        public MovieService(UserService userService)
        {
            this._userService = userService;
        }
    }
}
