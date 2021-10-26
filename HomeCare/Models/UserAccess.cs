using System;
using System.Text.RegularExpressions;

namespace HomeCare.Models
{
    public class UserAccess
    {
        public int UserId;
        public string Phone;
        public string Name;
        public bool IsManager;
        public bool HasRelleControl;
        public bool IsEnable;
        public bool IsDisable;
        public bool HasCall;
        public bool HasText;

        public bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
