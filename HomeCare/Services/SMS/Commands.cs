using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HomeCare.Services.SMS
{
    class Commands
    {
        public static string OpenCommand = "باز";
        public static string CloseCommand = "بسته";
        public static string PartialOpenCommand = "نیمه فعال";
        public static string WiretappingCommand = "شنود";
        public static string StatusCommand = "وضعیت";
        public static string ChargeCommand = "شارژ";
        public static void Open()
        {
            DependencyService.Get<ISendSms>().Send(Users.UserHandler.GetCurrentUser().phone, OpenCommand);
        }
        public static void Close()
        {
            DependencyService.Get<ISendSms>().Send(Users.UserHandler.GetCurrentUser().phone, CloseCommand);
        }
        public static void PartialOpen()
        {
            DependencyService.Get<ISendSms>().Send(Users.UserHandler.GetCurrentUser().phone, CloseCommand);
        }
        public static void Wiretapping()
        {
            DependencyService.Get<ISendSms>().Send(Users.UserHandler.GetCurrentUser().phone, WiretappingCommand);
        }
        public static void Status()
        {
            DependencyService.Get<ISendSms>().Send(Users.UserHandler.GetCurrentUser().phone, StatusCommand);
        }
        public static void Charge()
        {
            DependencyService.Get<ISendSms>().Send(Users.UserHandler.GetCurrentUser().phone, ChargeCommand);
        }
    }
}
