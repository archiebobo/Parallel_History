using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public class ph_Text
    {
        protected ph_Date begin;
        protected ph_Date end;
        protected string title;
        protected string text;
        protected string id;
        public ph_Text(string title, ph_Date begin, ph_Date end, string text)
        {
            this.title = title;
            this.begin = begin;
            this.end = end;
            this.text = text;
        }
        public string Title
        {
            get
            {
                return this.title;
            }
        }
        public string Text
        {
            get
            {
                return this.text;
            }
        }
        private ph_Date Begin
        {
            get
            {
                return this.begin;
            }
        }
        private ph_Date End
        {
            get
            {
                return this.end;
            }
        }
        private string GetID
        {
            get
            {
                return this.id;
            }
        }
    }
}
