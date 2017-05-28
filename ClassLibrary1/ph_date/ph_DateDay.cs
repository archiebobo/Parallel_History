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
                bool found = false;
                foreach (int m in new int[] { 1, 3, 5, 7, 8, 10, 12 })
                {
                    if (this.month == m)
                    {
                        if (this.day < 0 || this.day > 31)
                        {
                            this.response = new ph_Sys.ph_Sys_Response(1001103);
                        }
                        else
                        {
                            this.response = new ph_Sys.ph_Sys_Response(0);
                        }
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    foreach (int m in new int[] { 4, 6, 9, 11 })
                    {
                        if (this.month == m)
                        {
                            if (this.day < 0 || this.day > 30)
                            {
                                this.response = new ph_Sys.ph_Sys_Response(1001103);
                            }
                            else
                            {
                                this.response = new ph_Sys.ph_Sys_Response(0);
                            }
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                {
                    if ((this.year > 0 && this.year % 4 == 0) || (this.year < 0 && this.year % 4 == -1))
                    {
                        if (this.day < 0 || this.day > 29)
                        {
                            this.response = new ph_Sys.ph_Sys_Response(1001103);
                        }
                        else
                        {
                            this.response = new ph_Sys.ph_Sys_Response(0);
                        }
                    }
                    else
                    {
                        if (this.day < 0 || this.day > 28)
                        {
                            this.response = new ph_Sys.ph_Sys_Response(1001103);
                        }
                        else
                        {
                            this.response = new ph_Sys.ph_Sys_Response(0);
                        }
                    }
                }
            }
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
                        days = this.DayInYear - days-1;
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
