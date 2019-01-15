using System;

namespace MyMessenger
{
    class Messages
    {
        public Messages() { }

        public int MessageID { get; set; }
        public DateTime Date { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string UserMessage { get; set; }
        public Boolean Deleted { get; set; }

    }
}
