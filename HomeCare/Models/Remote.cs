using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    public class Remote
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public static List<Remote> GetAll()
        {
            var p = new List<Remote>();
            p.Add(new Remote() { Code = "+", Text = "اضافه" });
            p.Add(new Remote() { Code = "-", Text = "حذف" });
            p.Add(new Remote() { Code = "D", Text = "غیر فعال" });
            p.Add(new Remote() { Code = "E", Text = "فعال در تمامی ساعات" });
            p.Add(new Remote() { Code = "A", Text = "فعال فقط در شیفت 1" });
            p.Add(new Remote() { Code = "B", Text = "فعال فقط در شیفت 2" });
            p.Add(new Remote() { Code = "C", Text = "فعال در شیفت 1 و 2" });
            return p;
        }
    }
}
  