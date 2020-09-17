using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.AspNetCore.SignalR;

namespace BIMPlatform
{
    [Authorize]
    public class ChatHub : AbpHub
    {
    }
}
