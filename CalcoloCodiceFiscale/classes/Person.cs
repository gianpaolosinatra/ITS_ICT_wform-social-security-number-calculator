using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale.classes {
    class Person {

        //FIELDS
        private string _name = "";
        private string _surname = "";
        private string _gender = "";
        private int _birthYear = 0;
        private int _birthMonth = 0;
        private int _birthDay = 0;
        private string _birthplace = "";

        // GETTERS AND SETTERS
        public string getName() => _name;
        public void setName(string name) {
            _name = name;
        }

        public string getSurname() => _surname;
        public void setSurname(string surname) {
            _surname = surname;
        }

        public string getGender() => _gender;
        public void setGender(string gender) {
            _gender = gender;
        }

        public int getyear() => _birthYear;
        public void setyear(int year) {
            _birthYear = year;
        }

        public int getmonth() => _birthMonth;
        public void setmonth(int month) {
            _birthMonth = month;
        }

        public int getday() => _birthDay;
        public void setday(int day) {
            _birthDay = day;
        }

        public string getComune() => _birthplace;
        public void setComune(string comune) {
            _birthplace = comune;
        }

        //OTHER METHODS

        //...

        public override string ToString() {
            string txt = "name: "+_name+"\n";
            txt += "surname: "+_surname+"\n";
            txt += "Date of birth: " + _birthDay.ToString() +"/"+_birthMonth.ToString()+"/"+_birthYear.ToString()+"\n";
            txt += "gender: " + _gender + "\n";
            txt += "Comune di nascita: " + _birthplace + "\n";
            Console.WriteLine(txt);
            return txt;
        }




        //CONSTRUCTORS
        public Person(string name, string surname, string gender, int yearN, int monthN, int dayN, string comuneN) {
            _name = name;
            _surname = surname;
            _gender = gender;
            _birthYear = yearN;
            _birthMonth = monthN;
            _birthDay = dayN;
            _birthplace = comuneN;
        }

    }
}
