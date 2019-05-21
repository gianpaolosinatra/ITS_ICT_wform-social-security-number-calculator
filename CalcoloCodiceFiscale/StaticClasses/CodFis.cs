using CalcoloCodiceFiscale.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale {
    public static class CodFis {

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
         * NUMBER:      Is a character extracted from a table
        
         */


        static private string _name;
        static private string _surname;
        static private DateTime _birthdate;
        static private Gender _gender;
        static private string _municipalCode;

        public static void GetInfos(string name, string surname, DateTime bDate, Gender gender, string mCode) {
            _name = name;
            _surname = surname;
            _birthdate = bDate;
            _gender = gender;
            _municipalCode = mCode;

        }


        public static string  Generate() {
            string codFis = "";

            codFis += GenName(_name);
            codFis += GenSurname(_surname);
            codFis += _birthdate.ToString("yy");
            codFis += GenMonth(_birthdate.Month);
            codFis += (_gender == Gender.Male ? _birthdate.ToString("dd") : (_birthdate.Day + 40).ToString());
            codFis += GenRest(codFis);


            Console.WriteLine(codFis.ToUpper());
            return codFis;
            
        }




        private static string GenRest(string codFis) {
            int oddSum = 0, evenSum = 0;

            for (int i = 0; i < codFis.Length; i++) {
                if ((i + 1) % 2 == 0)
                    evenSum += CheckEven[codFis[i].ToString().ToUpper()];
                else
                    oddSum += CheckOdd[codFis[i].ToString().ToUpper()];

            }

            return CheckRest[(oddSum + evenSum) % 26];

        }

        private static string GenMonth(int month) {
            Dictionary<int, string> monthsDict = new Dictionary<int, string>() {
                [1] = "A",  [2] = "B",  [3] = "C",  [4] = "D",  [5] = "E",  [6] = "H",
                [7] = "L",  [8] = "M",  [9] = "P",  [10] = "R", [11] = "S", [12] = "T"
            };

            return monthsDict[month];
        }
                              
        private static string GenName(string name) {
            name = name.Replace(" ", "").Replace("'", "");
            string nameRes = "";
            string nameVowels = "";
            string nameCons = "";

            foreach (var lettera in name) {
                if (IsVowel(lettera))
                    nameVowels += lettera;
                else
                    nameCons += lettera;
            }

            if (name.Length < 3) {
                return nameCons + nameVowels + "X";
            }

            if (nameCons.Length == 3) {
                nameRes = nameCons;
            } else if (nameCons.Length > 3) {
                nameRes = nameCons.Substring(0, 1) + nameCons.Substring(2, 2);
            } else
                nameRes = nameCons + nameVowels.Substring(0, 3 - nameCons.Length);

            return nameRes;
        }
                              
        private static string GenSurname(string surname) {
            surname = surname.Replace(" ", "").Replace("'", "");
            string srnRes = "";
            string srnVowels = "";
            string srnCons = "";

            foreach (var lettera in surname) {
                if (IsVowel(lettera))
                    srnVowels += lettera;
                else
                    srnCons += lettera;
            }

            if (surname.Length < 3) {
                return srnCons + srnVowels + "X";
            }

            if (srnCons.Length >= 3)
                srnRes = srnCons.Substring(0, 3);
            else
                srnRes = srnCons + srnVowels.Substring(0, 3 - srnCons.Length);

            return srnRes;
        }

        private static Boolean IsVowel(char lettera) {
            return "aeiouAEIOU".Contains(Char.ToLower(lettera));

        }

        private static Dictionary<string, int> CheckOdd = new Dictionary<string, int>() {
            ["0"] = 1,
            ["1"] = 0,
            ["2"] = 5,
            ["3"] = 7,
            ["4"] = 9,
            ["5"] = 13,
            ["6"] = 15,
            ["7"] = 17,
            ["8"] = 19,
            ["9"] = 21,
            ["A"] = 1,
            ["B"] = 0,
            ["C"] = 5,
            ["D"] = 7,
            ["E"] = 9,
            ["F"] = 13,
            ["G"] = 15,
            ["H"] = 17,
            ["I"] = 19,
            ["J"] = 21,
            ["K"] = 2,
            ["L"] = 4,
            ["M"] = 18,
            ["N"] = 20,
            ["O"] = 11,
            ["P"] = 3,
            ["Q"] = 6,
            ["R"] = 8,
            ["S"] = 12,
            ["T"] = 14,
            ["U"] = 16,
            ["V"] = 10,
            ["W"] = 22,
            ["X"] = 25,
            ["Y"] = 24,
            ["Z"] = 23
        };

        private static Dictionary<string, int> CheckEven = new Dictionary<string, int>() {
            ["0"] = 0,
            ["1"] = 1,
            ["2"] = 2,
            ["3"] = 3,
            ["4"] = 4,
            ["5"] = 5,
            ["6"] = 6,
            ["7"] = 7,
            ["8"] = 8,
            ["9"] = 9,
            ["A"] = 0,
            ["B"] = 1,
            ["C"] = 2,
            ["D"] = 3,
            ["E"] = 4,
            ["F"] = 5,
            ["G"] = 6,
            ["H"] = 7,
            ["I"] = 8,
            ["J"] = 9,
            ["K"] = 10,
            ["L"] = 11,
            ["M"] = 12,
            ["N"] = 13,
            ["O"] = 14,
            ["P"] = 15,
            ["Q"] = 16,
            ["R"] = 17,
            ["S"] = 18,
            ["T"] = 19,
            ["U"] = 20,
            ["V"] = 21,
            ["W"] = 22,
            ["X"] = 23,
            ["Y"] = 24,
            ["Z"] = 25
        };

        private static Dictionary<int, string> CheckRest = new Dictionary<int, string>() {
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
