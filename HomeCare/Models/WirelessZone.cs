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
            var p = new List<WirelessZone>();
            p.Add(new WirelessZone() { Code = "+", Text = "اضافه" });
            p.Add(new WirelessZone() { Code = "-", Text = "حذف" });
            p.Add(new WirelessZone() { Code = "D", Text = "غیر فعال" });
            p.Add(new WirelessZone() { Code = "E", Text = "معمولی" });
            p.Add(new WirelessZone() { Code = "O", Text = "24 ساعته" });
            p.Add(new WirelessZone() { Code = "S", Text = "مخفی -اعالم توسط پیامک" });
            p.Add(new WirelessZone() { Code = "C", Text = "مخفی -اعالم توسط تماس" });
            p.Add(new WirelessZone() { Code = "H", Text = "پارت زون" });
            p.Add(new WirelessZone() { Code = "A", Text = "مخفی -اعالم توسط APP" });
            p.Add(new WirelessZone() { Code = "B", Text = "معمولی و پارت زون" });
            return p;
        }
    }
}