using CalcoloCodiceFiscale.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale.StaticClasses
{

    public static class CalcoloCodFis
    {
        static private string _name;
        static private string _surname;
        static private DateTime _birthdate;
        static private Gender _gender;
        static private string _municipalCode;


        public static string GetInfos()
        {
            return "";
        }
        public static string GenerateCF(string name, string surname, DateTime bDate, Gender gender, string cityname)
        {
            _name = name.ToUpper();
            _surname = surname.ToUpper();
            _birthdate = bDate;
            _gender = gender;
            _municipalCode = cityname.ToUpper();

            string fiscalCode = "";
            fiscalCode += GenSurname(_surname);
            fiscalCode += GenName(_name);
            fiscalCode += _birthdate.ToString("yy");
            fiscalCode += GenMonth(_birthdate.Month);
            fiscalCode += GenDay(_gender);
            fiscalCode += GetBelfioreCode(_municipalCode);

            return GenCIN(fiscalCode); 
        }

        public static string GenSurname(string surname)
        {
            surname = surname.Replace(" ", "").Replace("'", "");
            string surnameRes = "";
            string surnameVowels = "";
            string surnameCons = "";
            string finalSurname = "XXX";


            foreach (char c in surname)
            {//IsVowel(c) ? surnameVowels += c : surnameCons += c;
                if (IsVowel(c))
                    surnameVowels += c;
                else
                    surnameCons += c;
            }

            if (surnameCons.Length + surnameVowels.Length < 3)
                surnameRes = surnameCons + surnameVowels + finalSurname.Substring(0, 3 - (surnameCons.Length + surnameVowels.Length));
            else if (surnameCons.Length < 3)
                surnameRes = surnameCons + surnameVowels.Substring(0, 3 - surnameCons.Length);
            else
                surnameRes = surnameCons.Substring(0, 3);
            return surnameRes;
        }

        public static string GenName(string name)
        {
            name = name.Replace(" ", "").Replace("'", "");
            string nameRes = "";
            string nameVowels = "";
            string nameCons = "";
            string finalName = "XXX";


            foreach (char c in name)
            {//IsVowel(c) ? nameVowels += c : nameCons += c;
                if (IsVowel(c))
                    nameVowels += c;
                else
                    nameCons += c;
            }

            if (nameCons.Length > 3)
            {
                nameRes = nameCons.Remove(1, 1).Substring(0, 3);
            }
            else if (nameCons.Length + nameVowels.Length < 3)
                nameRes = nameCons + nameVowels + finalName.Substring(0, 3 - (nameCons.Length + nameVowels.Length));
            else if (nameCons.Length < 3)
                nameRes = nameCons + nameVowels.Substring(0, 3 - nameCons.Length);
            else
                nameRes = nameCons.Substring(0, 3);
            return nameRes;
        }

        public static bool IsVowel(char letter)
        {
            string vowels = "aeiouAEIOU";
            return vowels.Any(x => x.Equals(letter));
        }

        private static string GenMonth(int month)
        {
            Dictionary<int, string> monthsDict = new Dictionary<int, string>()
            {
                [1] = "A",
                [2] = "B",
                [3] = "C",
                [4] = "D",
                [5] = "E",
                [6] = "H",
                [7] = "L",
                [8] = "M",
                [9] = "P",
                [10] = "R",
                [11] = "S",
                [12] = "T"
            };

            return monthsDict[month];
        }

        private static string GenDay(Gender gender)
        {
            // Male = 0, Female = 1
            int dayOfBirth = gender == Gender.Male ? _birthdate.Day : _birthdate.Day + 40;
            return dayOfBirth.ToString();
        }

        private static string GetBelfioreCode(string cityName)
        {
            Dictionary<string, string> belfioreDict = new Dictionary<string, string>()
            {        
                ["CHIETI"] = "C632",
                ["DESIO"] = "D286",
                ["GELA"] = "D960",
                ["MILANO"] = "F205",
                ["PESCARA"] = "G482",
                ["ROMA"] = "H501",
                ["TORINO"] = "L219",
                ["VITTORIA"] = "M088"
            };

            return belfioreDict[cityName];
        }

        private static string GenCIN(string char15)
        {
            int result=0;
            for (int i = 0; i < char15.Length; i++)
            {
                if((i+1)%2==0)
                {
                    result += ChangeChar(char15[i], true);
                }
                else
                {
                    result += ChangeChar(char15[i], false);
                }
            }

            return char15+CheckRest[result % 26];
        }

        private static int ChangeChar(char letter, bool isEven)
        {
            if (isEven)
                return CheckEven[letter];            
            else
                return CheckOdd[letter];     
        }

        private static Dictionary<char, int> CheckOdd = new Dictionary<char, int>()
        {
            ['0'] = 1,
            ['1'] = 0,
            ['2'] = 5,
            ['3'] = 7,
            ['4'] = 9,
            ['5'] = 13,
            ['6'] = 15,
            ['7'] = 17,
            ['8'] = 19,
            ['9'] = 21,
            ['A'] = 1,
            ['B'] = 0,
            ['C'] = 5,
            ['D'] = 7,
            ['E'] = 9,
            ['F'] = 13,
            ['G'] = 15,
            ['H'] = 17,
            ['I'] = 19,
            ['J'] = 21,
            ['K'] = 2,
            ['L'] = 4,
            ['M'] = 18,
            ['N'] = 20,
            ['O'] = 11,
            ['P'] = 3,
            ['Q'] = 6,
            ['R'] = 8,
            ['S'] = 12,
            ['T'] = 14,
            ['U'] = 16,
            ['V'] = 10,
            ['W'] = 22,
            ['X'] = 25,
            ['Y'] = 24,
            ['Z'] = 23
        };

        private static Dictionary<char, int> CheckEven = new Dictionary<char, int>()
        {
            ['0'] = 0,
            ['1'] = 1,
            ['2'] = 2,
            ['3'] = 3,
            ['4'] = 4,
            ['5'] = 5,
            ['6'] = 6,
            ['7'] = 7,
            ['8'] = 8,
            ['9'] = 9,
            ['A'] = 0,
            ['B'] = 1,
            ['C'] = 2,
            ['D'] = 3,
            ['E'] = 4,
            ['F'] = 5,
            ['G'] = 6,
            ['H'] = 7,
            ['I'] = 8,
            ['J'] = 9,
            ['K'] = 10,
            ['L'] = 11,
            ['M'] = 12,
            ['N'] = 13,
            ['O'] = 14,
            ['P'] = 15,
            ['Q'] = 16,
            ['R'] = 17,
            ['S'] = 18,
            ['T'] = 19,
            ['U'] = 20,
            ['V'] = 21,
            ['W'] = 22,
            ['X'] = 23,
            ['Y'] = 24,
            ['Z'] = 25
        };

        private static Dictionary<int, string> CheckRest = new Dictionary<int, string>()
        {
            [0] = "A",
            [1] = "B",
            [2] = "C",
            [3] = "D",
            [4] = "E",
            [5] = "F",
            [6] = "G",
            [7] = "H",
            [8] = "I",
            [9] = "J",
            [10] = "K",
            [11] = "L",
            [12] = "M",
            [13] = "N",
            [14] = "O",
            [15] = "P",
            [16] = "Q",
            [17] = "R",
            [18] = "S",
            [19] = "T",
            [20] = "U",
            [21] = "V",
            [22] = "W",
            [23] = "X",
            [24] = "Y",
            [25] = "Z",
        };


    }
}


/* SOURCE → https://en.wikipedia.org/wiki/Italian_fiscal_code_card
         * COMPOSITION of Italian social security number ( 16 characters, lecters and numbers in this order: BBBCCC00D11E222F )
         * 1. The first 3 characters are letters (from Name);
         * 2. 4th, 5th, 6th characters are letters (from surname);
         * 3. 7th, 8th characters are two cyphers (from the year of birth);
         * 4. 9th character is a letter (from the month of birth);
         * 5. 10th, 11th characters are two cyphers (from the birth month by a role based on gender type);
         * 6. 12th character is a letter, 13th, 14th, 15th characters are three cyphers (from birthplace);
         * 7. 16th character is a letter (C.I.N.). It is the result of an algorithm that use previous fields;
         *
         * SURNAME=NAME:    The first three consonants of the name / surname, if they are not sufficient, take the consonants 
         *                  of the second name / surname up to 3. If the consonants of the name are not enough, after the 
         *                  consonants we begin to take the vowels (example: Tiziana → TZN, example2: Luca → LCU)
         * 
         * BIRTHYEAR:       We take the last two cyphers (example: 1989 → 89)
         * 
         * BIRTHMONTH:      Take the corresponding letter:
         *                  (January A), (February B), (March C), (April D), (May E), (June H), 
         *                  (July M), (August L), (September P), (October R), (NovemberS), (December T)
         * 
         * BIRTHDAY
         * AND GENDER:      2 cyphers,  if Male:            In range [1-9]th of month use 0 before like 01, 02, 03 ecc ... 09 else use original numbers [10-31]
         *                              else for Female:    It's the same but the number is increased by 40 [41-71]
         *                              
         * BIRTHPLACE:      Use the "Belfiore" code, is a code formed by 1 character and 3 cyphers.
         *  THIS IS A CODES LIST OF THE ITALIAN MUNICIPALITIES (regional capitals): 
         *   A271	Ancona	        A326	Aosta
         *   A345	L'Aquila	    A662	Bari
         *   A944	Bologna	        B354	Cagliari
         *   B519	Campobasso	    C352	Catanzaro
         *   D612	Firenze	        D969	Genova
         *   F205	Milano	        F839	Napoli
         *   G273	Palermo	        G478	Perugia
         *   G942	Potenza	        H501	Roma
         *   L219	Torino	        L378	Trento
         *   L424	Trieste	        L736	Venezia
         * 
         * Total Belfiore codes are here -> https://www1.agenziaentrate.gov.it/documentazione/versamenti/codici/ricerca/VisualizzaTabella.php?ArcName=COM-ICI
         * 
         * CONTROL INTERNAL
         * NUMBER (CIN):      
        
         */
