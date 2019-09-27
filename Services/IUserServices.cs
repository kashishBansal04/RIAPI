using Microsoft.AspNetCore.Mvc;
using RevInfotech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevInfotech.Services
{
    public interface IUserServices
    {
        (JsonResult result, bool Succeeded) CreateUserAsync(UserModel userModel);
        (JsonResult result, bool Succeeded) SignIn(Credentials Credentials);
    }
}
