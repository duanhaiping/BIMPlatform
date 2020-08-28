using BIMPlatform.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Platform.ToolKits.Extensions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Identity;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BIMPlatform.Authorize.Impl
{

    public class AuthorizeService : BIMPlatformAppService, IAuthorizeService
    {
        protected SignInManager<IdentityUser> SignInManager { get; }
        protected IdentityUserManager UserManager { get; }
        protected ISettingProvider SettingProvider { get; }
        public AuthorizeService(IdentityUserManager userManager, SignInManager<Volo.Abp.Identity.IdentityUser> signInManager, ISettingProvider settingProvider)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            SettingProvider = settingProvider;
        }
        public async Task<string> GenerateTokenAsync(string usernameOrEmailAddress, string password, bool rememberMe)
        {
            await CheckLocalLoginAsync();

            string result = string.Empty;
            ValidateLoginInfo(usernameOrEmailAddress, password);
            await ReplaceEmailToUsernameOfInputIfNeeds(usernameOrEmailAddress);
            SignInResult loginResult= await SignInManager.PasswordSignInAsync(usernameOrEmailAddress, password, rememberMe, true);
            if (loginResult.Succeeded)
            {
                var userByName = await UserManager.FindByNameAsync(usernameOrEmailAddress);
                var claims = new[] {
                    new Claim(ClaimTypes.Name, userByName.UserName),
                    new Claim(ClaimTypes.Email, userByName.Email),
                    new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(AppSettings.JWT.Expires)).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
                };
                var key = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes(System.Text.Encoding.UTF8));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var securityToken = new JwtSecurityToken(
                       issuer: AppSettings.JWT.Domain,
                       audience: AppSettings.JWT.Domain,
                       claims: claims,
                       expires: DateTime.Now.AddMinutes(AppSettings.JWT.Expires),
                       signingCredentials: creds);

                result = new JwtSecurityTokenHandler().WriteToken(securityToken);
              
            }
            else if (loginResult.IsLockedOut)
            {
                throw new Exception("登陆失败，账号被锁");
            }
            else if (loginResult.IsNotAllowed)
            {
                throw new Exception("登陆失败，不允许登陆");
            }
            else {
                throw new Exception("登陆失败，用户名或密码错误");
            }
            
            return  result;
        }

        protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds(string usernameOrEmailAddress)
        {
            if (!ValidationHelper.IsValidEmailAddress(usernameOrEmailAddress))
            {
                return;
            }
            var userByEmail = await UserManager.FindByEmailAsync(usernameOrEmailAddress);
            if (userByEmail == null)
            {
                return;
            }

            usernameOrEmailAddress = userByEmail.UserName;
        }


        private void ValidateLoginInfo(string usernameOrEmailAddress, string password)
        {
            if (StringExtensions.IsNullOrEmpty(usernameOrEmailAddress) || StringExtensions.IsNullOrEmpty(password))
                throw new ArgumentNullException();
        }

        public async Task LogOut()
        {
            await SignInManager.SignOutAsync();
        }

        public async Task<bool> CheckPassword(string usernameOrEmailAddress, string password)
        {
            ValidateLoginInfo(usernameOrEmailAddress, password);
            await ReplaceEmailToUsernameOfInputIfNeeds(usernameOrEmailAddress);
            var userByName = await UserManager.FindByNameAsync(usernameOrEmailAddress);
            if (userByName == null)
                throw new ArgumentNullException();
            var result= await SignInManager.CheckPasswordSignInAsync(userByName, password, true);
            if (result.Succeeded)
                return true;
            else
                return false;
        }

        protected virtual async Task CheckLocalLoginAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
            {
                throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
            }
        }
    }
}
