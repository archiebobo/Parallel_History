using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryPiece
{
    public enum Gen{Male,Female};
    public class ph_Person
    {
        private string name;
        private Gen gender;
        private ph_Date born;
        private ph_Date dead;
        private string culture;
        private string state;
        private string nationality;
        private string place_of_birth;
        private string info;
        public ph_Person(string name, Gen gender, string info)
        {
            this.name = name;
            this.gender = gender;
            this.culture = "";
            this.state = "";
            this.nationality = "";
            this.place_of_birth = "";
            this.info = info;
        }
        public ph_Person(string name, Gen gender, ph_Date born, string info)
        {
            this.name = name;
            this.gender = gender;
            this.born = born;
            this.culture = "";
            this.state = "";
            this.nationality = "";
            this.place_of_birth = "";
            this.info = "";
        }
        public ph_Person(string name, Gen gender, ph_Date born, ph_Date dead, string info)
        {
            this.name = name;
            this.gender = gender;
            this.born = born;
            this.culture = "";
            this.state = "";
            this.nationality = "";
            this.place_of_birth = "";
            this.info = "";
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }
        public Gen Gender
        {
            get
            {
                return this.gender;
            }
        }
        public ph_Date DateOfBirth
        {
            get
            {
                return this.born;
            }
        }
        public ph_Date DateOfDeadth
        {
            get
            {
                return this.dead;
            }
        }
        public string Culture
        {
            get
            {
                return this.culture;
            }
        }
        public string State
        {
            get
            {
                return state;
            }
        }
        public string Nationality
        {
            get
            {
                return this.nationality;
            }
        }
        public string PlaceOfBirth
        {
            get
            {
                return this.place_of_birth;
            }
        }
        private string Info
        {
            get
            {
                return this.info;
            }
        }
        public void SetCulture(string culture)
        {
            this.culture = culture;
        }
        public void SetState(string state)
        {
            this.state = state;
        }
        public void SetNationality(string nationality)
        {
            this.nationality = nationality;
        }
        public void SetPlaceOfBirth(string pob)
        {
            this.place_of_birth = pob;
        }
    }
}
