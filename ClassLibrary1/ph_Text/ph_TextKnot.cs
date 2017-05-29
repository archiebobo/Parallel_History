using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_TextKnot : ph_Text
    {
        private List<ph_TextKnot> knot_list;
        private string serial;
        private string chain_id;
        public ph_TextKnot(string title, ph_Date begin, ph_Date end, string text,string serial)
            : base(title, begin, end, text)
        {
            this.serial = serial;
            this.chain_id = this.id;
        }
        public ph_TextKnot(string title, ph_Date begin, ph_Date end, string text, string serial,string chain_id)
            : base(title, begin, end, text)
        {
            this.knot_list = new List<ph_TextKnot>();
            this.serial = serial;
            this.chain_id = chain_id;
        }
        public bool IsHead
        {
            get
            {
                foreach (char c in serial)
                {
                    if (c == ';')
                        return false;
                }
                return true;
            }
        }
        public bool IsSubHead
        {
            get
            {
                if (this.knot_list.Count != 0)
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