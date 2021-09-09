using System;

namespace HomeCare.Services.SMS
{
    public class SMSEvents
    {
        public static event EventHandler<SMSEventArgs> OnSMSReceived;

        public static void OnSMSReceived_Event(object sender, SMSEventArgs sms)
        {
            OnSMSReceived?.Invoke(sender, sms);
        } 
    }
    public interface ISendSms
    {
        void Send(string address, string message);
    }
    public class SMSEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
