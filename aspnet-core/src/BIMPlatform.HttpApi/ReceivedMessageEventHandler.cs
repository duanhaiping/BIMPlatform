using System.Threading.Tasks;
using BIMPlatform.Application.Contracts.RealTimeMessage;
using Microsoft.AspNetCore.SignalR;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace BIMPlatform
{
    public class ReceivedMessageEventHandler : IDistributedEventHandler<ReceivedMessageEto>, ITransientDependency
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ReceivedMessageEventHandler(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task HandleEventAsync(ReceivedMessageEto eto)
        {
            var message = $"{eto.SenderUserName}: {eto.ReceivedText}";

            await _hubContext.Clients
                .User(eto.TargetUserId.ToString())
                .SendAsync("ReceiveMessage", message);
        }
    }
}
