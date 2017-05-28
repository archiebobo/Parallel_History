using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public abstract class ph_DomainDate
    {
        protected ph_Date begin;
        protected ph_Date end;
        protected ph_Sys.ph_Sys_Response response;
        protected abstract void check_valid();
        public ph_Sys.ph_Sys_Response Response
        {
            get
            {
                return this.response;
            }
        }
    }
}
