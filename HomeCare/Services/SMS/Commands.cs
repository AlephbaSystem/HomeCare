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
            DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, OpenCommand);
        }
        public static void Close()
        {
            DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, CloseCommand);
        }
        public static void PartialOpen()
        {
            DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, CloseCommand);
        }
        public static void Wiretapping()
        {
            DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, WiretappingCommand);
        }
        public static void Status()
        {
            DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, StatusCommand);
        }
        public static void Charge()
        {
            DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, ChargeCommand);
        }
    }
}
