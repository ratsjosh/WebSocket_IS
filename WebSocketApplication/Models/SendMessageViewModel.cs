using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocketApplication.Models
{
    public class SendMessageViewModel
    {
        public SendMessageViewModel() { }
        public SendMessageViewModel(string _sender, string _message, bool _isPrivateMessage)
        {
            Sender = _sender;
            Message = _message;
            IsPrivateMessage = _isPrivateMessage;
        }

        public string Sender { get; set; }

        public string Message { get; set; }

        public bool IsPrivateMessage { get; set; } = true;
    }
}
