using CalcoloCodiceFiscale.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale.StaticClasses {
    public static class CFCalc {

        static private string _name;
        static private string _surname;
        static private DateTime _birthdate;
        static private Gender _gender;
        static private string _municipalCode;

        public static void GetInfos(string name, string surname, DateTime bDate, Gender gender, string mCode ) {
            _name = name;
            _surname = surname;
            _birthdate = bDate;
            _gender = gender;
            _municipalCode = mCode;

        }
        



    }
}
