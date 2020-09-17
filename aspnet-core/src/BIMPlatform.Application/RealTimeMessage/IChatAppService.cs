using BIMPlatform.Application.Contracts.RealTimeMessage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BIMPlatform.RealTimeMessage
{
    public interface IChatAppService : IApplicationService
    {
        Task SendMessageAsync(SendMessageInput input);
    }
}
