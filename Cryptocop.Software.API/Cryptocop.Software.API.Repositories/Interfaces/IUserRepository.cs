﻿using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserDto CreateUser(RegisterInputModel inputModel);
        UserDto AuthenticateUser(LoginInputModel loginInputModel);
    }
}
