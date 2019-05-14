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
         * NUMBER:      
        
         */

        public static void ManupilationName(string name) {

            name
            
        }




        public static string CheckData(string date) {
               

            return 
        }

      

        public static void Calcolo() {

                Console.WriteLine("Inserire il cognome: ");
                var cognome = Console.ReadLine();

                Console.WriteLine("Inserire il nome: ");
                var nome = Console.ReadLine();

                Console.WriteLine("Inserire il genere (F - M): ");
                var genere = Console.ReadLine();

                Console.WriteLine("Inserire il data di nascita (Formato gg/mm/aaaa): ");
                var dataNascita = "#" + Console.ReadLine() + "#";
                while (!IsDate(dataNascita)) {
                    Console.WriteLine("Formato data inserito non valido, inserire formato corretto -> gg/mm/aaaa): ");
                    dataNascita = "#" + Console.ReadLine() + "#";
                }

                Console.WriteLine("Inserire il comune di nascita: ");
                var comune = Console.ReadLine();


        }
        
    }
}
