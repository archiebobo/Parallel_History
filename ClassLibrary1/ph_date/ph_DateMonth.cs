using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_DateMonth : ph_DateYear
    {
        public ph_DateMonth(int year, int month)
            : base(year)
        {
            this.month = month;
            this.day = 0;
            valid_check();
        }
        protected override void valid_check()
        {
            base.valid_check();
            if (this.Response.IsSeccess)
            {
                if (this.month < 0 || this.month > 12)
                {
                    this.response = new ph_Sys.ph_Sys_Response(1001102);
                }
                else
                {
                    this.response = new ph_Sys.ph_Sys_Response(0);
                }
            }
        }
        public static ph_DomainMonth operator -(ph_DateMonth fir, ph_DateMonth sec)
        {
            return new ph_DomainMonth(sec, fir);
        }
        public static ph_DateMonth operator +(ph_DateMonth a, int b)
        {
            int t_year = b / 12;
            int t_month = b % 12;
            a.year += t_year;
            if (a.year == 0)
            {
                a.year++;
            }
            a.month += t_month;
            if (a.month > 12)
            {
                a.year++;
                a.month = a.month - 12;
                if (a.year == 0)
                {
                    a.year++;
                }
            }
            if (a.year == 0)
            {
                a.year++;
            }
            a.valid_check();
            return a;
        }
        public static ph_DateMonth operator +(ph_DateMonth a, ph_DomainMonth b)
        {
            int m = b.MonthDomain;
            a = a + m;
            return a;
        }
        public static ph_DateMonth operator ++(ph_DateMonth a)
        {
            return a + 1;
        }
        public int Month
        {
            get
            {
                return this.month;
            }
        }
        public int DaysOfMonth
        {
            get
            {
                List<int> m31 = new List<int> { 1, 3, 5, 7, 8, 10, 12 };
                List<int> m30 = new List<int> { 4, 6, 9, 11 };
                foreach (int i in m31)
                {
                    if (this.month == i)
                        return 31;
                }

                foreach (int i in m30)
                {
                    if (this.month == i)
                        return 30;
                }

                if (this.IsLeapYear)
                    return 29;
                else
                    return 28;
            }
        }
    }
}
