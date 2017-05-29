using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_DateDay : ph_DateMonth
    {
        public ph_DateDay(int year, int month, int day)
            : base(year, month)
        {
            this.day = day;
            this.valid_check();
        }
        protected override void valid_check()
        {
            base.valid_check();
            if (this.Response.IsSeccess)
            {
                if (this.day < 0 || this.day > this.DaysOfMonth)
                {
                    this.response = new ph_Sys.ph_Sys_Response(1001103);
                }
                else
                {
                    this.response = new ph_Sys.ph_Sys_Response(0);
                }
            }
        }
        public static ph_DomainDay operator -(ph_DateDay fir, ph_DateDay sec)
        {
            return new ph_DomainDay(sec, fir);
        }
        public static ph_DateDay operator +(ph_DateDay a, int b)
        {
            if (a.Response.IsSeccess)
            {
                if (a.Day + b < a.DaysOfMonth)
                {
                    a.day = a.day + b;
                }
                else
                {
                    if (a.DayInYear + b <= a.DaysOfYear)
                    {
                        b -= a.DaysOfMonth - a.day + 1;
                        a.month++;
                        a.day = 1;
                        while (b != 0)
                        {

                            if (b <= a.DaysOfMonth - a.Day)
                            {
                                a.day = a.day + b;
                                break;
                            }
                            else
                            {
                                b -= a.DaysOfMonth;
                                a.month++;
                            }
                        }
                    }
                    else
                    {
                        b += a.DayInYear - 1;
                        a.day = 1;
                        a.month = 1;
                        while (b > a.DaysOfYear - 1)
                        {
                            b -= a.DaysOfYear;
                            a.year++;
                            a.year = a.year == 0 ? 1 : a.year;
                        }
                        while (b != 0)
                        {

                            if (b <= a.DaysOfMonth - a.Day)
                            {
                                a.day = a.day + b;
                                break;
                            }
                            else
                            {
                                b -= a.DaysOfMonth;
                                a.month++;
                            }
                        }
                    }
                }
                return a;
            }
            else
            {
                return new ph_DateDay(a.Year, a.Month, a.Day);
            }
        }
        public static ph_DateDay operator +(ph_DateDay a, ph_DomainDay b)
        {
            int m = b.DayDomain;
            a = a + m;
            return a;
        }
        public static ph_DateDay operator ++(ph_DateDay a)
        {
            return a + 1;
        }
        public int Day
        {
            get
            {
                return this.day;
            }
        }
        public int DayInYear
        {
            get
            {
                if (this.response.IsSeccess)
                {
                    int days = 0;
                    foreach (int m in new int[] { 1, 3, 5, 7, 8, 10, 12 })
                    {
                        if (m >= this.Month)
                        {
                            break;
                        }
                        else
                        {
                            days += 31;
                        }
                    }
                    foreach (int m in new int[] { 2, 4, 6, 9, 11 })
                    {
                        if (m >= this.Month)
                        {
                            break;
                        }
                        else
                        {
                            days += 30;
                        }
                    }
                    if (this.Month > 2)
                    {
                        if ((this.Year % 4 == 0 && this.Year > 0) || (this.Year % 4 == -1 && this.Year < 0))
                        {
                            days--;
                        }
                        else
                        {
                            days -= 2;
                        }
                    }
                    days += this.day;
                    return days;
                }
                else
                {
                    return -1;
                }
            }
        }
        public int AbsoluteDay
        {
            get
            {
                if (this.Response.IsSeccess)
                {
                    int days = 0;
                    if (this.Year > 0)
                    {
                        days += (this.Year - 1) / 4 * 1461 + (this.Year - 1) % 4 * 365 + this.DayInYear;
                        return days;
                    }
                    else
                    {
                        for (int i = 1; i <= -this.Year; i++)
                        {
                            if (i % 4 == 1)
                            {
                                days += 366;
                            }
                            else
                            {
                                days += 365;
                            }
                        }
                        days = this.DayInYear - days - 1;
                        return days;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
