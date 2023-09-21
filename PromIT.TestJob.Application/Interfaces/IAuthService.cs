using Microsoft.AspNetCore.Identity;
using PromIT.TestJob.Application.ViewModels;

namespace PromIT.TestJob.Application.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> Login(LoginViewModel model);
        Task Logout();
        Task<IdentityResult> Register(RegisterViewModel model);
    }
}