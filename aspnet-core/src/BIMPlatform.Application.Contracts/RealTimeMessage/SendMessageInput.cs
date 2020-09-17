using System;
using System.Collections.Generic;
using System.Text;

namespace BIMPlatform.Application.Contracts.RealTimeMessage
{
    public class SendMessageInput
    {
        public string TargetUserName { get; set; }

        public string Message { get; set; }
    }
}
