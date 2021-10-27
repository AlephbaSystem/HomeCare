using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HomeCare.Services.SMS
{
    class Commands
    {
        public static string OpenCommand = "باز";
        public static string CloseCommand = "قفل";
        public static string PartialOpenCommand = "نیمه";
        public static string WiretappingCommand = "شنود";
        public static string StatusCommand = "وضعیت";
        public static string ChargeCommand = "شارژ";
        public static string ResetCommand = "RESET";
        public static string FactoryCommand = "0000#*";
        public static string ReleCommand = "رله";
        public static string ZoneCommand = "زون";
        public static string TrafficCommand = "تردد";
        public static string ReportCommand = "گزارش";
        public static string UserCommand = "کاربر";

        /// <summary>
        /// غیرفعال کردن دستگاه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Open()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, OpenCommand))
                return true;
            return false;
        }

        /// <summary>
        /// فعال کردن دستگاه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Close()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, CloseCommand))
                return true;
            return false;
        }

        /// <summary>
        /// نیمه فعال کردن دستگاه (پارت زون)
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool PartialOpen()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, PartialOpenCommand))
                return true;
            return false;
        }

        /// <summary>
        /// درخواست شنود صدای محیط
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Wiretapping()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, WiretappingCommand))
                return true;
            return false;
        }

        /// <summary>
        /// دریافت وضعیت دستگاه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Status()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, StatusCommand))
                return true;
            return false;
        }

        /// <summary>
        /// استعالم اعتبار باقی مانده سیم کارت دستگاه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Charge()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, ChargeCommand))
                return true;
            return false;
        }

        /// <summary>
        /// استعالم وضعیت رله های دستگاه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Rele()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, ReleCommand))
                return true;
            return false;
        }

        /// <summary>
        /// استعالم وضعیت زون های سیمی
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Zone()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, ZoneCommand))
                return true;
            return false;
        }

        /// <summary>
        /// درخواست گزارش از رویدادهای فعال و غیرفعال شدن دستگاه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Traffic()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, TrafficCommand))
                return true;
            return false;
        }

        /// <summary>
        /// درخواست گزارش از تمامی رویدادها
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool Report()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, ReportCommand))
                return true;
            return false;
        }

        /// <summary>
        /// درخواست لیست کاربران
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool User()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, UserCommand))
                return true;
            return false;
        }

        /// <summary>
        /// نحوه ثبت اولین شماره به عنوان مالک
        /// </summary> 
        /// <param name="permission">نوع دسترسی</param>
        /// <param name="userId">شماره کاربر</param>
        /// <param name="phone">شماره همراه کاربر</param>
        /// <returns>Bool</returns>
        public static bool AddUser(int userId, string phone, string permission)
        {
            string command = $"{userId}#{phone}{permission}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// حذف کاربر
        /// </summary> 
        /// <param name="userId">شماره کاربر</param>
        /// <returns>Bool</returns>
        public static bool RemoveUser(int userId)
        {
            string command = $"DUR{userId}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// ویرایش سطح دسترسی کاربر
        /// </summary> 
        /// <param name="permission">نوع دسترسی</param>
        /// <param name="phone">شماره همراه کاربر</param>
        /// <returns>Bool</returns>
        public static bool ChangePermission(string phone, string permission)
        {
            string command = $"{phone}EUA{permission}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تعویض شماره مالک دستگاه
        /// </summary> 
        /// <param name="phone">شماره همراه کاربر</param>
        /// <returns>Bool</returns>
        public static bool ChangeOwner(string phone)
        {
            string command = $"CHG{phone}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// فعال سازی ارسال گزارش رویدادها به مالک
        /// </summary> 
        /// <param name="permission">نوع فعال سازی</param>
        /// <returns>Bool</returns>
        public static bool EnableReports(string permission)
        {
            string command = $"MAS{permission}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تعریف شیفت برای کاربر
        /// </summary> 
        /// <param name="userId">شماره کاربر</param>
        /// <param name="shift">شماره شیفت</param>
        /// <param name="hmStart">ساعت و دقیقه شیفت شروع (0755)</param>
        /// <param name="hmEnd">ساعت و دقیقه شیفت پایان (1630)</param>
        /// <returns>Bool</returns>
        public static bool CreateShift(int userId, int shift, string hmStart, string hmEnd)
        {
            if (hmStart.Length < 4 || hmEnd.Length < 4)
            {
                return false;
            }
            string command = $"{userId}USH{shift}{hmStart}{hmEnd}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// فعال سازی شیفت برای کاربر
        /// </summary>  
        /// <param name="userId">شماره کاربر</param>
        /// <param name="shift">نوع شیفت</param>
        /// <returns>Bool</returns>
        public static bool UserShift(int userId, string shift)
        {
            string command = $"{userId}UCS{shift}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// استعالم وضعیت کاربر
        /// </summary> 
        /// <param name="userId">شماره کاربر</param>
        /// <returns>Bool</returns>
        public static bool UserInquire(int userId)
        {
            string command = $"UDT{userId}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// راه اندازی مجدد دستگاه
        /// </summary>  
        /// <returns>Bool</returns>
        public static bool FullReset()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, ResetCommand))
                return true;
            return false;
        }

        /// <summary>
        /// پاک شدن حافظه دستگاه و بازگشت تنظیمات به پیشفرض کارخانه
        /// </summary> 
        /// <returns>Bool</returns>
        public static bool FactoryReset()
        {
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, FactoryCommand))
                return true;
            return false;
        }

        /// <summary>
        /// تنظیم تقویم و ساعت داخلی
        /// فیلد سال با کسر مقدار 1400 محاسبه می شود.
        /// </summary> 
        /// <param name="yr">دوحرف آخر سال (01)</param>
        /// <param name="mh">ماه (01)</param>
        /// <param name="dy">روز (01)</param>
        /// <param name="hr">ساعت (10)</param>
        /// <param name="mn">دقیقه (33)</param>
        /// <returns>Bool</returns>
        public static bool SetTime(string yr, string mh, string dy, string hr, string mn)
        {
            string command = $"TIME{yr}{mh}{dy}{hr}{mn}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تنظیمات زون سیمی
        /// برای تنظیم سطح حساسیت و نوع زون از این دستور استفاده می شود.
        /// </summary> 
        /// <param name="zoneNumber">شماره زون : بین 0 تا 9</param>
        /// <param name="zoneType">نوع زون</param>
        /// <param name="sensitivity">برای زون های نرمال کلوز عدد 1 و برای زون های نرمال اپن عدد 0</param>
        /// <returns>Bool</returns>
        public static bool SetZone(int zoneNumber, string zoneType, int sensitivity)
        {
            if (zoneNumber > 9 || zoneNumber < 0)
            {
                return false;
            }
            if (sensitivity > 1 || sensitivity < 0)
            {
                return false;
            }
            string command = $"Z{zoneNumber}{zoneType}{sensitivity}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تنظیم زون سیمی به عنوان پارت زون
        /// شماره زون هایی ارسال می شود به عنوان پارت زون عمل خواهند کرد.
        /// </summary> 
        /// <param name="zoneNumbers">تعریف زون ها به عنوان پارت زون.</param> 
        /// <returns>Bool</returns>
        public static bool SetPartZone(string zoneNumbers)
        {
            string command = $"PRT{zoneNumbers}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تعریف زون بی سیم
        /// </summary> 
        /// <param name="zoneNumber">به صورت عدد 2 رقمی از 01 تا 51</param> 
        /// <param name="operation">نوع عملیات</param> 
        /// <returns>Bool</returns>
        public static bool SetWirelessZone(string zoneNumber, string operation)
        {
            string command = $"WZ{zoneNumber}{operation}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تعریف ریموت
        /// </summary> 
        /// <param name="userId">شماره کاربر: 0 تا 9</param> 
        /// <param name="remoteNumber">شماره ریموت : 0 تا 8</param> 
        /// <param name="operation">نوع عملیات</param> 
        /// <returns>Bool</returns>
        public static bool SetRemote(int userId, int remoteNumber, string operation)
        {
            string command = $"{userId}RM{remoteNumber}{operation}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تنظیم مدت زمان آژیر
        /// با تنظیم این زمان هنگام فعال شدن آژیر ، صدای آژیر یا سیرن پس از سپری شدن زمان مشخص شده قطع می شود .
        /// واحد زمان به دقیقه و حتما باید به صورت دو رقمی وارد شود.
        /// </summary> 
        /// <param name="duration">زمان باید عددی بین 00 تا 99 باشد.</param>  
        /// <returns>Bool</returns>
        public static bool SetAlarmDuration(string duration)
        {
            if (duration.Length < 2)
            {
                return false;
            }
            string command = $"ALT{duration}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تنظیم مدت زمان خروج
        /// با تنظیم این حالت پس از فعال شدن دستگاه و سپری شدن این حالت ، با تحریک زون ها دستگاه آژیر می زند.
        /// واحد زمان به دقیقه و حتما باید به صورت دو رقمی وارد شود.
        /// </summary> 
        /// <param name="duration">زمان باید عددی بین 00 تا 99 باشد.</param>  
        /// <returns>Bool</returns>
        public static bool SetExitDuration(string duration)
        {
            if (duration.Length < 2)
            {
                return false;
            }
            string command = $"OTT{duration}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// تنظیم حالت گارد بلندگو
        /// با تنظیم این حالت در صورتی که بلندگو معیوب شود یا سیم ارتباطی به هر دلیلی دچار قطعی شود دستگاه این رویداد
        /// را با پیامک و تماس به کاربران اطالع می دهد.
        /// </summary> 
        /// <param name="status">وضعیت</param>  
        /// <returns>Bool</returns>
        public static bool SetGuard(bool status)
        {
            int s = status ? 1 : 0;
            string command = $"ALS{s}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }

        /// <summary>
        /// کنترل رله ها
        /// </summary> 
        /// <param name="rele">شماره رله از عدد 1 تا 3</param>  
        /// <param name="status">وضعیت : 0 خاموش و 1 روشن</param>  
        /// <returns>Bool</returns>
        public static bool ReleControl(int rele, bool status)
        {
            if (rele > 3 || rele < 1)
            {
                return false;
            }
            int s = status ? 1 : 0;
            string command = $"{rele}#{status}";
            if (DependencyService.Get<ISendSms>().Send(new Users.UserHandler().GetCurrentUser().Phone, command))
                return true;
            return false;
        }
    }
}
