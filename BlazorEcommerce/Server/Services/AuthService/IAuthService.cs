﻿namespace BlazorEcommerce.Server.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<int>> Register(User user, string password);
    Task<bool> UserExists(string email);
    Task<ServiceResponse<string>> Login(string username, string password);
}