using BIMPlatform.Application.Contracts.RealTimeMessage;
using BIMPlatform.RealTimeMessage;
using Microsoft.AspNetCore.Mvc;
using Platform.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMPlatform.Controllers.Chat
{
    public class ChatController : BaseController
    {
        private readonly IChatAppService _chatAppService;

        public ChatController(IChatAppService chatAppService)
        {
            _chatAppService = chatAppService;
        }
        [HttpPost]
        public async Task<ServiceResult> SendMessageAsync(SendMessageInput input)
        {
            await _chatAppService.SendMessageAsync(input);
            return await ServiceResult.IsSuccess();
        }
    }
}
