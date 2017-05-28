using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoryPiece;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ph_HistoryPiece cc = new ph_HistoryPiece(Nation.China,2007,2007,"haah","haha");
            ph_Date dd = new ph_Date(-1,2,29);
            Console.Write(dd.Response);
            Console.ReadKey();
        }
    }
}
