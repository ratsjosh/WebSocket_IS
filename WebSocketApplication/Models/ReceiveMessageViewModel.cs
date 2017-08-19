using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocketApplication.Models
{
    public class ReceiveMessageViewModel
    {
        public ReceiveMessageViewModel() { }
        public ReceiveMessageViewModel(string _reciever, string _message)
        {
            Receiver = _reciever;
            Message = _message;
        }
        public string Receiver { get; set; }

        public string Message { get; set; }
    }
}
