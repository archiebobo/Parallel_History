using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_DomainDay : ph_DomainMonth
    {
        public ph_DomainDay(ph_DateDay begin, ph_DateDay end)
            : base(begin, end)
        {
            this.begin = begin;
            this.end = end;
            this.check_valid();
        }
        protected override void check_valid()
        {
            base.check_valid();
            if (this.Response.IsSeccess)
            {
                if (!this.begin.Response.IsSeccess)
                {
                    this.response = this.begin.Response;
                }
                else
                {
                    if (!this.begin.Response.IsSeccess)
                    {
                        this.response = this.end.Response;
                    }
                    else
                    {
                        if ((this.begin as ph_DateDay).Month < (this.end as ph_DateDay).Month)
                        {
                            this.response = new ph_Sys.ph_Sys_Response(0);
                        }
                        else
                        {
                            if ((this.begin as ph_DateDay).Day > (this.end as ph_DateDay).Day)
                            {
                                this.response = new ph_Sys.ph_Sys_Response(1001203);
                            }
                            else
                            {
                                this.response = new ph_Sys.ph_Sys_Response(0);
                            }
                        }
                    }
                }
            }
        }
        public int DayDomain
        {
            get
            {
                if (this.Response.IsSeccess)
                {
                    if ((this.begin as ph_DateDay).Year < 0 && (this.end as ph_DateDay).Year > 0)
                    {
                        return (this.end as ph_DateDay).AbsoluteDay - (this.begin as ph_DateDay).AbsoluteDay - 1;
                    }
                    else
                    {
                        return (this.end as ph_DateDay).AbsoluteDay - (this.begin as ph_DateDay).AbsoluteDay;
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
