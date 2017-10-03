using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.Entities
{
    public class UserService : IService {

        public UserDto GetUser(string email) {
            if (!ValidationUtil.IsValidEmail(email))
                throw new ArgumentException("Must be a properly formatted email", nameof(email));
            UserDto toReturn = null;
            toReturn = Users?.FirstOrDefault(user => user?.Email == email);
            return toReturn;
        }

        public bool AreCredentialsValid(string email, string password) {
            bool toReturn = false;
            if (!ValidationUtil.IsValidEmail(email))
                throw new ArgumentException("Must be a properly formatted email", nameof(email));
            if (password == null)
                new ArgumentNullException(nameof(password));
            UserDto user = this.GetUser(email);
            if (user?.Email == email && user?.Password == password)
                toReturn = true;
            return toReturn;
        }

        public UserDto GetUserIfCredentialsAreValid(string email, string password) {
            UserDto toReturn = null;
            if (AreCredentialsValid(email, password))
                toReturn = GetUser(email);
            return toReturn;
        }

        public static IEnumerable<UserDto> Users = new List<UserDto>() {
            new UserDto {Id = 1, Email = "test@test.com", Password = "Password"},
            new UserDto {Id = 2, Email = "test1@test.com", Password = "Password"},
            new UserDto {Id = 3, Email = "test2@test.com", Password = "Password"}
        };

    }
}
