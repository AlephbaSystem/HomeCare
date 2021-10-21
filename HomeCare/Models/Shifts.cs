using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Models
{
    public class Shifts
    {
        public string Code { get; set; }
        public string Text { get; set; }

        public static List<Shifts> GetAll()
        {
            var p = new List<Shifts>();
            p.Add(new Shifts() { Code = "F", Text = "شیفت 1 و 2" });
            p.Add(new Shifts() { Code = "A", Text = "شیفت 1" });
            p.Add(new Shifts() { Code = "B", Text = "شیفت 2" });
            p.Add(new Shifts() { Code = "D", Text = "بدون شیفت" });
            return p;
        }
    }
}
