﻿using System;
using System.Text.RegularExpressions;

namespace HomeCare.Models
{
    public class UserAccess
    {
        public string UserId;
        public string Phone;
        public string Name;
        public bool IsManager;
        public bool HasRelleControl;
        public bool IsEnable;
        public bool IsDisable;
        public bool HasCall;
        public bool HasText;
        public int mask;

        public UserAccess(string id, string phone, string name, bool manager=false, bool relay= false, bool enable=false, bool disable=false, bool call=false, bool text=false)
        {
            UserId = id;
            Phone = phone;
            Name = name;
            IsManager = manager;
            HasRelleControl = relay;
            IsEnable = enable;
            IsDisable = disable;
            HasCall = call;
            HasText = text;
            mask = 0;
            if(HasRelleControl)
            {
                mask = mask | (1 << 1);
            }
            if(IsEnable)
            {
                mask = mask | (1 << 2);
            }
            if(IsDisable)
            {
                mask = mask | (1 << 3);
            }
            if(HasCall)
            {
                mask = mask | (1 << 4);
            }
            if(HasText)
            {
                mask = mask | (1 << 5);
            }
            if(IsManager)
            {
                mask = 63;
            }
        }

        public bool IsValidPhone()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Phone))
                    return false;
                var r = new Regex(@"^(?:0|98|\+98|\+980|0098|098|00980)?(9\d{9})$");
                return r.IsMatch(this.Phone);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetAccess()
        {
            switch(mask)
            {
                case 44:
                    return "A";
                case 28:
                    return "B";
                case 36:
                    return "C";
                case 2:
                    return "D";
                case 60:
                    return "E";
                case 63:
                    return "F";
                case 20:
                    return "G";
                case 62:
                    return "H";
                case 6:
                    return "I";
                case 14:
                    return "J";
                case 40:
                    return "K";
                case 24:
                    return "L";
                case 46:
                    return "M";
                case 30:
                    return "N";
                case 10:
                    return "O";
                case 42:
                    return "P";
                case 12:
                    return "Q";
                case 8:
                    return "R";
                case 4:
                    return "S";
                case 48:
                    return "T";
                case 56:
                    return "U";
                case 52:
                    return "W";
                case 58:
                    return "X";
                case 54:
                    return "Y";
                case 26:
                    return "Z";

                case 34:
                    return "a";
                case 50:
                    return "b";
                case 16:
                    return "c";
                case 18:
                    return "d";
                case 32:
                    return "e";

            }
            return "";
        }
    }
}
