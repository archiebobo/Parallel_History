using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_DateYear : ph_Date
    {
        public ph_DateYear(int year)
        {
            this.year = year;
            this.valid_check();
            this.month = 0;
            this.day = 0;
        }
        protected override void valid_check()
        {
            if (this.year < -6000 || this.year > 2100 || this.year == 0)
            {
                this.response = new ph_Sys.ph_Sys_Response(1001101);
            }
            else
            {
                this.response = new ph_Sys.ph_Sys_Response(0);
            }
        }
        public static ph_DomainYear operator -(ph_DateYear fir, ph_DateYear sec)
        {
            return new ph_DomainYear(sec, fir);
        }
        public static ph_DateYear operator +(ph_DateYear a, int b)
        {
            a.year += b;
            if (a.year == 0)
            {
                a.year++; 
            }
            a.valid_check();
            return a;
        }
        public static ph_DateYear operator +(ph_DateYear a, ph_DomainYear b)
        {
            a.year += b.YearDomain;
            if (a.year == 0)
            {
                a.year++;
            }
            a.valid_check();
            return a;
        }
        public static ph_DateYear operator ++(ph_DateYear a)
        {
            return a + 1;
        }
        public int Year
        {
            get
            {
                return this.year;
            }
        }
        public bool IsLeapYear
        {
            get
            {
                if ((this.year > 0 && this.year % 4 == 0) || (this.year < 0 && this.year % 4 == -1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public int DaysOfYear
        {
            get
            {
                return this.IsLeapYear ? 366 : 365;
            }
        }
    }
}
