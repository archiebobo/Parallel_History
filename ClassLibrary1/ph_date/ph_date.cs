using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public enum DateType { Gregorian, Lunar, Jewish, Japanese };
    public abstract class ph_Date
    {
        protected int year;
        protected int month;
        protected int day;
        protected ph_Sys.ph_Sys_Response response;
        protected abstract void valid_check();
        public ph_Sys.ph_Sys_Response Response
        {
            get
            {
                return this.response;
            }
        }
    }
}