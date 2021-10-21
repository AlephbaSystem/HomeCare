using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    public class Zone
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public static List<Zone> GetAll()
        {
            var p = new List<Zone>();
            p.Add(new Zone() { Code = "D", Text = "غیر فعال" });
            p.Add(new Zone() { Code = "E", Text = "معمولی" });
            p.Add(new Zone() { Code = "O", Text = "ساعته 24" });
            p.Add(new Zone() { Code = "S", Text = "مخفی -اعالم توسط پیامک" });
            p.Add(new Zone() { Code = "C", Text = "مخفی -اعالم توسط تماس" });
            p.Add(new Zone() { Code = "H", Text = "" });
            p.Add(new Zone() { Code = "A", Text = "مخفی -اعالم توسط APP" });
            p.Add(new Zone() { Code = "B", Text = "معمولی و پارت زون" });
            return p;
        }
    }
}
