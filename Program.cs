
// Välkomnande meddelande
// En lista för att spara historik för räkningar
// Användaren matar in tal och matematiska operation
//OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet
// Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
// Lägga resultat till listan
//Visa resultat
//Fråga användaren om den vill visa tidigare resultat.
//Visa tidigare resultat DONE
//Fråga användaren om den vill avsluta eller fortsätta.

//FÖRBÄTTRINGAR
//Jag hade kunnat använda mig mer utav metoder för att undvika att ha så mycket upprepande kod som jag har i det här programmet.
//Jag hade även kunnat förbättra programmet så att det skulle gå att använda sig utav negativa tal när man använder sig av miniräknaren
//Det hade även gått att göra om programmet så att man skulle kunna räkna större tal eller med olika räknesätt tex 10+5*2
//Försökte mig på att göra så att man kan sortera listan så det går att sortera men den sorteras inte efter summan så det är en förbättring man skulle kunna göra med.
//Man kan även få in lite grafik i den här miniräknaren i form av knappar med alla siffror och räknesätt som en riktig miniräknare
//Man skulle även kunna förbättra programmet genom att använda sig av piltagenter för att navigera i menyn istället för siffror.
//Jag har inte använt mig utav något speciellt design mönster till den här uppgiften, det är något man kan förbättra att analysera olika design mönster
//innan man börjar med kodandet för att se vilket som skulle passa bäst till projektet man gör.


//Ändrar färg på texten till röd, skriver ut ett välkomstmeddelande samt en tom rad efter.
//Deklarerar en List som ska spara ner alla beräkningar, ger programmet titeln Kalkylator, deklarerar en string variabel som ska användas i while loopen
using Kalkylator;
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("                 Välkommen till Miniräknaren skapad av Filip!");
Console.WriteLine("                ---------------------------------------------");
Console.WriteLine();
List<string> beräkningar = new List<string>();
Console.Title = "Kalkylator";
string menyLoop = "";

//Skapar en whileloop för menyn
while (menyLoop != "70")
{
    //Skriv ut meny med hjälp av min metod SkrivUtMeny, samt tar in data från användaren
    Class1.SkrivUtMeny();
    menyLoop = Console.ReadLine();

    //Skapar en switch case loop för att få tillgång till de olika menyvalen som finns i metoden SkrivUtMeny
    switch (menyLoop)
    {
        //Case 1 innehåller alla räkneoperationer, Console clear för att rensa det som visades innan case1
        //While true sålänge jag skriver in siffror så låter den mig fortsätta 
        //Ber användaren skriva in ett tal samt läser in det talet och sparar det i variabeln matteTal, skickar ut en beep signal när talet är inskrivet
        //använder mig sedan utav contains för att ta reda på vilket räknesätt vi behöver använda oss utav
        //skriver vi in 5+5 så förstår programmet att vi ska räkna + och skriver vi 10-5 så förstår det att vi ska använda minus
        case "1":
            Console.Clear();
            string matteTal = "";
            while (true)
            {
                Console.WriteLine("Skriv in ett tal du vill räkna ut");
                matteTal = Console.ReadLine();
                Console.Beep();
                Console.Clear();

                //Om vi väljer att använda oss av addition så kommer denna kod att köras
                //Använder mig av indexof, först gör jag en int som vi sedan använder oss utav för att kunna identifiera plusstecknet
                //Efter det så behöver jag dela upp talet vi skriver in och spara det till 2 separata varaiblar för att kunna räkna med de senare
                //Den här raden innebär att vi letar upp talet som är till vänster om plusstecknet och sparar det string tal1TextPluss = matteTal[..plussIndex];
                //Det här är egentligen samma sak men vi letar efter talet till höger om plusstecknet string tal2TextPluss = matteTal[(plussIndex + 1)..];
                //Deklarerar 2 bool variablar och använder mig utav TryParse för att senare kunna ta reda på om det verkligen är en siffra
                //Visar det sig att talet vi skriver in inte är tal så får vi skriva in ett nytt tal ända tills vi skriver in ett riktigt tal
                //Annars så kommer vi att skriva ut talet och sedan spara ner det i listan beräkningar
                if (matteTal.Contains("+"))
                {

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

                        användSiffror();
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
                //Om vi väljer att använda oss av subtraktion så körs denna kod
                //Koden är identisk i alla fyra räknesätt det som skiljer är variabelnamn samt att uträkningarna är specifika för varje räknesätt
                if (matteTal.Contains("-"))
                {
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
                        användSiffror();
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
                //Om vi väljer att använda oss av multiplikation så körs denna kod
                //Koden är identisk i alla fyra räknesätt det som skiljer är variabelnamn samt att uträkningarna är specifika för varje räknesätt
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
                        användSiffror();
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
                //Om vi väljer att använda oss av subtraktion så körs denna kod
                //Koden är identisk i alla fyra räknesätt det som skiljer är variabelnamn samt att uträkningarna är specifika för varje räknesätt
                //Här skiljer sig koden dock lite mot de andra 4 räknesätten eftersom vi vill kunna skriva ut ett felmeddelande om man delar ett tal med 0
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
                        //Console.WriteLine("Skriv in siffror");
                        användSiffror();
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
            break;
        //Om man väljer val 2 i menyn så kommer denna kod att köras
        //Vi börjar med att rensa allt som tidigare visats sedan skriver vi ut stränge här är dina senaste beräkningar
        //För att kunna skriva ut allting som är sparat i listan beräkningar så använder jag mig utav en foreach loop
        //det foreach loopen gör är att gå igenom alla index i listan och sedan väljer jag att skriva ut allt
        case "2":
            {
                Console.Clear();
                Console.WriteLine("Här är dina senaste beräkningar");


                foreach (string tal in beräkningar)
                {

                    Console.WriteLine(tal);
                }
            }
            break;
        //Frågar användaren en extra gång om de verkligen vill radera allt innehåll i listan
        //Skickar sedan ut 3 varningsljud med hjälp av console.Beep();
        //Sedan skapar vi en string variabel som vi användet till att spara ner användarens val i
        //Med hjälp av en else if sats tar vi reda på om användaren skriver in y eller n
        //Beroende på vad användaren svarar så kommer listan att raderas eller så kommer den inte att raderas
        case "3":
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
                break;
            }
            break;
        //Frågar användaren om hen vill sortera listan sedan sparar vi ner svaret i en variabel och med else if sats tar 
        //vi reda på om vi ska sortera listan eller inte vill användaren göra det så använder vi oss utav en sorteringsmetod
        //Skulle användaren svara något annat än y/n så kommer programmet skriva ut att man ska ange antingen y eller n
        case "4":
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
            break;
        //Frågar användaren om den vill avsluta programmet eller inte
        //när vi har tagit reda på det så använder vi oss utav två ilika while loopar svarar användren n så kommer
        //man tillbaka till menyn men svarar man istället y så kommer programmet direkt att avslutas
        case "5":
            Console.WriteLine("Är du säker på att du vill Avsluta(y/n)");
            string avsluta = Console.ReadLine();
            while (avsluta == "n")
            {
                Console.Clear();
                Console.WriteLine("Återgår till menyn");
                break;
            }
            while (avsluta == "y")
            {
                Console.Clear();
                Console.WriteLine("Stänger av programmet. . .");
                Environment.Exit(0);
            }
            break;
        //Om användaren inte gör ett val mellan 1-5 så blir man påmind om att man måste göra ett val från 1-5
        default:
            Console.WriteLine("Vänligen skriv in en siffra mellan (1-5)");
            break;
    }
}

//här är en metod för att skriva ut att man ska använda siffror om man skulle skriva in bokstäver när man räknar ut ett tal i miniräknaren
string användSiffror()
{
    string returnVärde = "";
    bool fungerar = false;
    bool fungerar2 = false;
    if (!fungerar || !fungerar2)
    {
        Console.WriteLine("Skriv in siffror");
    }
    return returnVärde;
}