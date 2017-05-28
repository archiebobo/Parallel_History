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
        public int Year
        {
            get
            {
                return this.year;
            }
        }
    }
}
