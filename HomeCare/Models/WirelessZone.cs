using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    public class WirelessZone
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public static List<WirelessZone> GetAll()
        {
            var p = new List<Zone>();
            p.Add(new Zone() { Code = "+", Text = "اضافه" });
            p.Add(new Zone() { Code = "-", Text = "حذف" });
            p.Add(new Zone() { Code = "D", Text = "غیر فعال" });
            p.Add(new Zone() { Code = "E", Text = "معمولی" });
            p.Add(new Zone() { Code = "O", Text = "24 ساعته" });
            p.Add(new Zone() { Code = "S", Text = "مخفی -اعالم توسط پیامک" });
            p.Add(new Zone() { Code = "C", Text = "مخفی -اعالم توسط تماس" });
            p.Add(new Zone() { Code = "H", Text = "پارت زون" });
            p.Add(new Zone() { Code = "A", Text = "مخفی -اعالم توسط APP" });
            p.Add(new Zone() { Code = "B", Text = "معمولی و پارت زون" });
            return p;
        }
    }
}