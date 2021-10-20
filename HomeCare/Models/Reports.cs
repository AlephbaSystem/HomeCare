using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    public class Reports
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public static List<Reports> GetAll()
        {
            var p = new List<Reports>();
            p.Add(new Reports() { Code = "F", Text = "تمام رویداد ها" });
            p.Add(new Reports() { Code = "A", Text = "فقط رویداد فعال و غیرفعال سازی" });
            p.Add(new Reports() { Code = "C", Text = "فقط رویدادهای مربوط به ویرایش تنظیمات دستگاه" });
            p.Add(new Reports() { Code = "R", Text = "فقط رویدادهای مربوط به ویرایش وضعیت رله ها" });
            p.Add(new Reports() { Code = "D", Text = "غیرفعال کردن ارسال گزارشات به مالک" });
            return p;
        }
    }
}
