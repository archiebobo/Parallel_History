using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ph_Sys
{
    public enum ph_Response { 
        Seccess = 0, 
        UnkownError = -1 , 
        DateError = 1001 };
    public class ph_Sys_Response
    {
        private int code;
        public ph_Sys_Response(bool yn)
        {
            if (yn)
            {
                code = 0;
            }
            else
            {
                code = 1;
            }
        }
        public ph_Sys_Response(int yn)
        {
            this.code = yn;
        }
        public ph_Response Report
        {
            get
            {
                return (ph_Response)this.code;
            }
        }
        public int Code
        {
            get
            {
                return this.code;
            }
        }
        public bool IsSeccess
        {
            get
            {
                if (this.code == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
