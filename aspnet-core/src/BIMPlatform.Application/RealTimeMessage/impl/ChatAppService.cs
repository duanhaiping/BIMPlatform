using BIMPlatform.Application.Contracts.RealTimeMessage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EventBus.Distributed;

namespace BIMPlatform.RealTimeMessage.impl
{
    public class ChatAppService : BaseService, IChatAppService
    {
       
        private readonly IDistributedEventBus _distributedEventBus;
        public ChatAppService( IDistributedEventBus distributedEventBus)
        {
            _distributedEventBus = distributedEventBus;
        }
        public async Task SendMessageAsync(SendMessageInput input)
        {
            Guid targetId =new Guid(input.TargetUserName);
            await _distributedEventBus.PublishAsync(new ReceivedMessageEto(targetId, CurrentUser.UserName, input.Message));
        }
    }
}
