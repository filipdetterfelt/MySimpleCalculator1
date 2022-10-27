using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kalkylator
{
    //Skapar en class som heter Class1
    internal class Class1
    {
        //Skapar en medtod som skriver ut menyn ändrar färger på texten och gör själva menyn lite roligare genom att
        //rama in den
        public static void SkrivUtMeny()
        {

            //Denna meny använde jag mig av först men kom sedan på att jag ville ha lite olika färger i form av varanan röd
            //och blå så då blev det svårt att använda denna

            //Console.WriteLine("Välj ett följande menyval 1-5\n" +
            //" 1. Använd miniräknaren\n " +
            //    "2. Visa tidigare uträkningar\n " +
            //     "3. Rensa innehåll i listan\n" +
            //     " 4. Sortera listan\n" +
            //     " 5. Avsluta programmet");

            Console.WriteLine("                     _________________________________");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                    | Välj ett följande menyval (1-5) |");
            Console.WriteLine("                     _________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    | 1.   Använd miniräknaren        |");
            Console.WriteLine("                     _________________________________");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                    | 2.  Visa tidigare uträkningar   |");
            Console.WriteLine("                     _________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    | 3.   Rensa innehåll i listan    |");
            Console.WriteLine("                     _________________________________");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                    | 4.     Sortera listan           |");
            Console.WriteLine("                     _________________________________");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                    | 5.    Avsluta programmet        |");
            Console.WriteLine("                    |_________________________________|");


        }
        //Här är en metod som var tänkt att använda för att kalla på menyn lyckades inte få den att fungera dock
        public static void HelaMenyn()
        {
            List<string> beräkningar = new List<string>();
            Console.Clear();
            string matteTal = "";
            while (true)
            {
                Console.WriteLine("Skriv in ett tal du vill räkna ut");
                matteTal = Console.ReadLine();
                Console.Beep();
                Console.Clear();

                if (matteTal.Contains("+"))
                {
                    //För att ite krrascha vid inmatningen av annat ön siffror while loop och tryparsr
                    int plussIndex = matteTal.IndexOf("+");
                    string tal1TextPluss = matteTal[..plussIndex];
                    string tal2TextPluss = matteTal[(plussIndex + 1)..];
                    double tal1Pluss;
                    bool fungerar = double.TryParse(tal1TextPluss, out tal1Pluss);
                    double tal2Pluss;
                    bool fungerar2 = double.TryParse(tal2TextPluss, out tal2Pluss);
                    double summaPluss = tal1Pluss + tal2Pluss;
                    if (!fungerar || !fungerar2)
                    {
                        Console.WriteLine("Skriv in siffror");
                    }
                    else
                    {
                        string helaTalet = matteTal + " " + "=" + " " + summaPluss;
                        Console.WriteLine($"{matteTal} = {summaPluss}");
                        Console.WriteLine();
                        beräkningar.Add(helaTalet);
                        break;
                    }
                }

                if (matteTal.Contains("-"))
                {
                    //Följande kod är för att räkna ut minus
                    int minusIndex = matteTal.IndexOf("-");
                    string tal1TextMinus = matteTal[..minusIndex];
                    string tal2TextMinus = matteTal[(minusIndex + 1)..];
                    double tal1Minus;
                    bool fungerar = double.TryParse(tal1TextMinus, out tal1Minus);
                    double tal2Minus;
                    bool fungerar2 = double.TryParse(tal2TextMinus, out tal2Minus);
                    double summaMinus = tal1Minus - tal2Minus;
                    if (!fungerar || !fungerar2) ;
                    {
                        Console.WriteLine("Skriv in siffror");
                    }
                    if (fungerar || fungerar2)
                    {
                        string helaTalet = matteTal + " " + "=" + " " + summaMinus;
                        Console.WriteLine($"{matteTal} = {summaMinus}");
                        Console.WriteLine();
                        beräkningar.Add(helaTalet);
                        break;
                    }

                }
                if (matteTal.Contains("*"))
                {
                    //Följande kod är för att räkna ut gånger
                    int gångerIndex = matteTal.IndexOf("*");
                    string tal1TextGånger = matteTal[..gångerIndex];
                    string tal2TextGånger = matteTal[(gångerIndex + 1)..];
                    double tal1Gånger;
                    bool fungerar = double.TryParse(tal1TextGånger, out tal1Gånger);
                    double tal2Gånger;
                    bool fungerar2 = double.TryParse(tal2TextGånger, out tal2Gånger);
                    double summaGånger = tal1Gånger * tal2Gånger;
                    if (!fungerar || !fungerar2)
                    {
                        Console.WriteLine("Skriv in siffror");
                    }
                    else
                    {
                        string helaTalet = matteTal + " " + "=" + " " + summaGånger;
                        Console.WriteLine($"{matteTal} = {summaGånger}");
                        Console.WriteLine();
                        beräkningar.Add(helaTalet);
                        break;
                    }
                }
                if (matteTal.Contains("/"))
                {
                    //Följande kod är för att räkna ut delat
                    int delatIndex = matteTal.IndexOf("/");
                    string tal1TextDelat = matteTal[..delatIndex];
                    string tal2TextDelat = matteTal[(delatIndex + 1)..];
                    double tal1Delat;
                    bool fungerar = double.TryParse(tal1TextDelat, out tal1Delat);
                    double tal2Delat;
                    bool fungerar2 = double.TryParse(tal2TextDelat, out tal2Delat);
                    double summaDelat = tal1Delat / tal2Delat;
                    if (tal2Delat == 0)//OAvsätt tal delat med 0
                    {
                        Console.WriteLine("Oj något blev fel");
                        break;
                    }
                    if (!fungerar || !fungerar2)
                    {
                        Console.WriteLine("Skriv in siffror");
                    }
                    else
                    {
                        string helaTalet = matteTal + " " + "=" + " " + summaDelat;
                        Console.WriteLine($"{matteTal} = {summaDelat}");
                        Console.WriteLine();
                        beräkningar.Add(helaTalet);
                        break;
                    }
                }
            }

            {
                Console.Clear();
                Console.WriteLine("Här är dina senaste beräkningar");
                Console.WriteLine();

                foreach (string tal in beräkningar)
                {
                    Console.WriteLine(tal);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("OBS allt innehåll i listan kommer att raderas är du säker (y/n)");
            Console.Beep();
            Console.Beep();
            Console.Beep();
            string raderaAllt = Console.ReadLine();
            if (raderaAllt == "y")
            {
                beräkningar.Clear();
                Console.WriteLine("Listan är nu tom");
            }
            else if (raderaAllt == "n")
            {
                Console.WriteLine("Då behåller vi listan");
                Console.ReadKey();

            }

            Console.WriteLine("Vill du sortera listan (y/n)?");
            string sorteraListan = Console.ReadLine();
            if (sorteraListan == "y")
            {
                beräkningar.Sort();
                Console.WriteLine("Nu är din lista sorterad från minsta till största summa");
            }
            else if (sorteraListan == "n")
            {
                Console.WriteLine("Då sorterar vi inte listan");
            }
            else Console.WriteLine("Vänligen ange (y/n)");

            //DETTA FUNGERAR EJ 
            //För att lösa detta kolla på annan lösning än while(menyLoop !=3)
            //Kanske kan använda bool o sätta den false/true
            Console.WriteLine("Vill du Avsluta Programmet? (y/n)");
            string avslutaProgram = Console.ReadLine();
            switch (avslutaProgram)
            {
                case "y":
                    Console.WriteLine("Avslutar program");
                    Environment.Exit(0);
                    break;

                case "n":
                    Console.WriteLine("Då återgår vi till menyn");
                    break;
            }
            Console.WriteLine("Vänligen skriv in en siffra mellan (1-5)");
        }
    }
}