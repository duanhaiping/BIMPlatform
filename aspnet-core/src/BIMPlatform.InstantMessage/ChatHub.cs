using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.SignalR;

namespace BIMPlatform.RealTimeMessage
{
    [Authorize]
    public class ChatHub : AbpHub
    {
    }
}
