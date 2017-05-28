using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_DomainMonth : ph_DomainYear
    {
        public ph_DomainMonth(ph_DateMonth begin, ph_DateMonth end)
            : base(begin, end)
        {
            this.begin = begin;
            this.end = end;
            this.check_valid();
        }
        protected override void check_valid()
        {
            base.check_valid();
            if (this.response.IsSeccess)
            {
                if (!this.begin.Response.IsSeccess)
                {
                    this.response = this.begin.Response;
                }
                else
                {
                    if (!this.end.Response.IsSeccess)
                    {
                        this.response = this.end.Response;
                    }
                    else
                    {
                        if ((this.begin as ph_DateMonth).Year < (this.end as ph_DateMonth).Year)
                        {
                            this.response = new ph_Sys.ph_Sys_Response(0);
                        }
                        else
                        {
                            if ((this.begin as ph_DateMonth).Month > (this.end as ph_DateMonth).Month)
                            {
                                this.response = new ph_Sys.ph_Sys_Response(1001202);
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
        public int MonthDomain
        {
            get
            {
                if (this.response.IsSeccess)
                {
                    return this.YearDomain * 12 - (this.begin as ph_DateMonth).Month + (this.end as ph_DateMonth).Month;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
