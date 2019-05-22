using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcoloCodiceFiscale.Enums;
using CalcoloCodiceFiscale.StaticClasses;

namespace CalcoloCodiceFiscale {
    class Program {
        static void Main(string[] args) {

            /* FINAL SCOPE
             * User must insert following dates:
             * Name
             * Surname
             * Date of birth -> gg/mm/aaaa
             * Birthplace
             * Gender
             * Output: Italian social security number.
             */


            Console.WriteLine("Insert Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Insert Surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Insert Date of Birth (dd/MM/yyyy): ");
            string dateString = Console.ReadLine();
            DateTime bDate = Convert.ToDateTime(dateString);

            Console.WriteLine("Insert Gender (F - M): ");
            char gender = Console.ReadKey().KeyChar;
            Gender genderType = gender.Equals('F')||gender.Equals('f') ? Gender.Female : Gender.Male;
            Console.WriteLine();

            Console.WriteLine("Insert City of Birth: ");
            string cityname = Console.ReadLine();

            Console.WriteLine(CalcoloCodFis.GenerateCF(name, surname, bDate, genderType, cityname));
            
            Console.Read();


        }
    }
}
