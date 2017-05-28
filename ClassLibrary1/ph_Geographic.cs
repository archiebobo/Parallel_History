using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public enum Contnt { Africa, Asia, Australia, Europe, SouthAmerica, NorthAmerica, Unkown }
    public enum SubContnt { Africa, Indian, MidEast, FarEast, Australia, EasternEurope, NorthernEurope, SouthernEurope, WesternEurope, SouthAmerica, NorthAmerica, Unkown }
    class ph_Region
    {
        string name;
        SubContnt sub_continent;
        public ph_Region(SubContnt sub_continent)
        {
            this.sub_continent = sub_continent;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public SubContnt SubContinent
        {
            get
            {
                return this.sub_continent;
            }
        }
        public Contnt Continent
        {
            get
            {
                switch (this.sub_continent)
                {
                    case SubContnt.Africa: return Contnt.Africa; 
                    case SubContnt.Australia: return Contnt.Australia; 
                    case SubContnt.EasternEurope: return Contnt.Europe; 
                    case SubContnt.NorthernEurope: return Contnt.Europe; 
                    case SubContnt.SouthernEurope: return Contnt.Europe; 
                    case SubContnt.WesternEurope: return Contnt.Europe; 
                    case SubContnt.Indian: return Contnt.Asia; 
                    case SubContnt.MidEast: return Contnt.Asia; 
                    case SubContnt.FarEast: return Contnt.Asia; 
                    case SubContnt.SouthAmerica: return Contnt.SouthAmerica;
                    case SubContnt.NorthAmerica: return Contnt.NorthAmerica;
                    default: return Contnt.Unkown;
                }
            }
        }
    }
}
