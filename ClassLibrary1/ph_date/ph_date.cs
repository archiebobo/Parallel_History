using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public enum DateType { Gregorian, Lunar, Jewish, Japanese };
    public abstract class ph_Date
    {
        protected int year;
        protected int month;
        protected int day;
        protected ph_Sys.ph_Sys_Response response;
        protected abstract void valid_check();
        public static bool operator >(ph_Date a, ph_Date b)
        {
            if (a.year > b.year)
            {
                return true;
            }
            else if (a.year < b.year)
            {
                return false;
            }
            else
            {
                if (a.month > b.month)
                {
                    return true;
                }
                else if (a.month < b.month)
                {
                    return false;
                }
                else
                {
                    if (a.day > b.day)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public static bool operator <(ph_Date a, ph_Date b)
        {
            if (a > b)
                return false;
            else if (a == b)
                return false;
            else
                return true;
        }
        public static bool operator >=(ph_Date a, ph_Date b)
        {
            if (a > b || a == b) return true;
            else return false;
        }
        public static bool operator <=(ph_Date a, ph_Date b)
        {
            if (a < b || a == b) return true;
            else return false;
        }
        public ph_Sys.ph_Sys_Response Response
        {
            get
            {
                return this.response;
            }
        }
    }
}