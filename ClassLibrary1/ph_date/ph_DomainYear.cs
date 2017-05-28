using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_DomainYear : ph_DomainDate
    {
        public ph_DomainYear(ph_DateYear begin, ph_DateYear end)
        {
            this.begin = begin;
            this.end = end;
            check_valid();
        }
        protected override void check_valid()
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
                    if ((this.begin as ph_DateYear).Year > (this.end as ph_DateYear).Year)
                    {
                        this.response = new ph_Sys.ph_Sys_Response(1001201);
                    }
                    else
                    {
                        this.response = new ph_Sys.ph_Sys_Response(0);
                    }
                }
            }
        }
        public int YearDomain
        {
            get
            {
                if (this.response.IsSeccess)
                {
                    if ((this.begin as ph_DateYear).Year < 0 && (this.end as ph_DateYear).Year > 0)
                    {
                        return (this.end as ph_DateYear).Year - (this.begin as ph_DateYear).Year - 1;
                    }
                    else
                    {
                        return (this.end as ph_DateYear).Year - (this.begin as ph_DateYear).Year;
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
