using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcoloCodiceFiscale {
    public static class CodFis {

        /* 3 lettere cognome + 3 lettere nome + annoNascita 2 cifre + meseNascita 1 lettera + gionoNascita e genere 2 lettere + comune/statoNascita 1 lettera e 3 cifre + 1 carattere controllo
        *
        * COGNOME=NOME: le prime tre consonanti del primo cognome/nome, se non bastano (contando secondi cognomi/nomi) si prelevano (DOPO) anche le vocali
        * 
        * ANNONASCITA: ultime due cifre
        * 
        * MESENASCITA:  una lettera dall'array 1=(A gennaio) 2=(B febbraio) 3=(C Marzo) 4=(D Aprile) 5=(E Maggio) 6=(H Giugno) 7=(M Luglio) 8=(L Agosto) 9=(P Settembre) 10=(R Ottobre) 11=(S Novembre) 12=(T Dicembre)
        * 
        * GIORNONASCITA E GENERE: 2 cifre,  se M:   se il giorno compreso tra 1-9 si mette lo zero davanti 01, 02, 03 ecc ... 09
        *                                   se F:   uguale a M ma sommando 40
        * COMUNENASCITA: rifarsi al codice Belfiore codice (catastale) dei comuni 1 lettera + 3 cifre   
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
        * CARATTERE DI CONTROLLO: 
        

        
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
        */
    }
}
