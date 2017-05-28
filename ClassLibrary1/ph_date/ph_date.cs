using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public enum DateType { Gregorian, Lunar, Jewish, Japanese };
    public class ph_date
    {
        private enum Era { BCE, CE };
        private int year;
        private int month;
        private int day;
        private DateType date_type;
        private ph_Sys.ph_Sys_Response response;
        public ph_date(int y) 
        {
            this.year = y;
            this.month = 0;
            this.day = 0;
            this.date_type = DateType.Gregorian;
            this.response=new ph_Sys.ph_Sys_Response(test_date());
        }
        public ph_date(int y, int m) 
        {
            this.year = y;
            this.month = m;
            this.day = 0;
            this.date_type = DateType.Gregorian;
            this.response = new ph_Sys.ph_Sys_Response(test_date());
        }
        public ph_date(int y, int m, int d)
        {
            this.year = y;
            this.month = m;
            this.day = d;
            this.date_type = DateType.Gregorian;
            this.response = new ph_Sys.ph_Sys_Response(test_date());
        }
        protected int test_date()
        {
            if (this.year == 0)
            {
                this.reset_init();
                return 1001;
            }
            if (this.month < 0 || this.month > 12)
            {
                this.reset_init();
                return 1001;
            }
            else
            {
                foreach (int i in new int[] { 1, 3, 5, 7, 8, 10, 12 })
                {
                    if (i == this.month)
                    {
                        if (this.day < 0 || this.day > 31)
                        {
                            this.reset_init();
                            return 1001;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                foreach (int i in new[] { 4, 6, 9, 11 })
                {
                    if (i == this.month)
                    {
                        if (this.day < 0 || this.day > 30)
                        {
                            this.reset_init();
                            return 1001;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                if (this.year / 4 == 0)
                {
                    if (this.day < 0 || this.day > 29)
                    {
                        this.reset_init();
                        return 1001;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (this.day < 0 || this.day > 28)
                    {
                        this.reset_init();
                        return 1001;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
        protected void reset_init()
        {
            this.year = 0;
            this.month = 0;
            this.day = 0;
        }
        public ph_Sys.ph_Sys_Response Response
        {
            get
            {
                return this.response;
            }
        }
        public string TextYear
        {
            get
            {
                if (this.year > 0)
                {
                    return this.year + Era.CE.ToString();
                }
                else
                {
                    return this.year + Era.BCE.ToString();
                }
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
        }
        public int Month
        {
            get
            {
                return this.month;
            }
        }
        public int Day
        {
            get
            {
                return this.day;
            }
        }
        public DateType TypeOfDate
        {
            get
            {
                return this.date_type;
            }
        }
        public int DaysFromEra
        {
            get
            {
                int days = 0;
                days += (this.year - 1) / 4 * 1461;
                days += (this.year - 1) % 4 * 365;
                for (int i = 1; i < this.month; i++)
                {
                    bool found = false;
                    foreach (int j in new int[] { 1, 3, 5, 7, 8, 10 })
                    {
                        if (j == i)
                        {
                            days += 31;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        foreach (int j in new int[] { 4, 6, 9, 11 })
                        {
                            if (j == i)
                            {
                                days += 30;
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        if (this.year % 4 == 0)
                        {
                            days += 29;
                        }
                        else
                        {
                            days += 28;
                        }
                    }
                }
                days += this.day;
                if (days == -365)
                {
                    days = 0;
                }
                return days;
            }
        }
    }
}
