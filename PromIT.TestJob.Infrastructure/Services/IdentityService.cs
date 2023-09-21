using Microsoft.AspNetCore.Identity;
using PromIT.TestJob.Application.Interfaces;
using PromIT.TestJob.Application.ViewModels;

namespace PromIT.TestJob.Infrastructure.Services
{
    public class IdentityService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public IdentityService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.UserName };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }

            return result;
        }

        public async Task<SignInResult> Login(LoginViewModel model)
            => await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        public async Task Logout()
            => await _signInManager.SignOutAsync();
    }
}
