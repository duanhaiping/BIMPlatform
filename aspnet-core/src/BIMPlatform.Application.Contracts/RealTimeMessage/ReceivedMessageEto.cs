using System;
using System.Collections.Generic;
using System.Text;

namespace BIMPlatform.Application.Contracts.RealTimeMessage
{
    public class ReceivedMessageEto
    {
        public string ReceivedText { get; set; }

        public Guid TargetUserId { get; set; }

        public string SenderUserName { get; set; }

        public ReceivedMessageEto(Guid targetUserId, string senderUserName, string receivedText)
        {
            ReceivedText = receivedText;
            TargetUserId = targetUserId;
            SenderUserName = senderUserName;
        }
    }
}
