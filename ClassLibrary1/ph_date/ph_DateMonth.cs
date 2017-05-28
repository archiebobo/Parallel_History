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
        public int Month
        {
            get
            {
                return this.month;
            }
        }
    }
}
