using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.Authorize
{
    public interface IAuthorizeService
    {
        Task<string > GenerateTokenAsync(string usernameOrEmailAddress, string password,bool rememberMe);
        Task LogOut();
        Task<bool> CheckPassword(string usernameOrEmailAddress, string password);
    }
}
