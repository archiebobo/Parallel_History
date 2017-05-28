using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public enum Nation { China, India, Japan };
    public class ph_HistoryPiece
    {
        private Nation nation;
        private int begin;
        private int end;
        private string title;
        private string text;
        public ph_HistoryPiece(Nation nation, int begin, int end, string title, string text) 
        {
            this.nation = nation;
            this.begin = begin;
            this.end = end;
            this.title = title;
            this.text = text;
        }
    }
}
