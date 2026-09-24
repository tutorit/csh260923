using Course;


void Variables()
{
    Console.WriteLine("Hello, World!");

    int a = 32;
    a = 54;
    Int32 b = 64; // int ja Int32 ovat synonyymit

    double db = 3.14;

    string tx = "Hello";
    tx += " maailma";
    tx += a;

    var c = 43; // c on int
    var d = "Hello"; // d on string

    dynamic e = "Hello";  // e on string
    Console.WriteLine(e.GetType());
    e = 32;  // e muuttuu int-tyyppiseksi
    Console.WriteLine(e.GetType());
}

void ArraysList()
{
    string wds = "Ma,Ti,Ke,To,Pe,La,Su";
    Console.WriteLine("Viikonpäivät: " + wds);
    string[] wda = wds.Split(",");
    Console.WriteLine(wda[1]);
    wda[1] = "Tiis";
    foreach (string wd in wda)
    {
        Console.WriteLine(wd);
    }
    List<string> wdl = new List<string>(wda);
    foreach (string wd in wdl)
    {
        Console.WriteLine(wd);
    }
}

int PromptForIntAlkuperainen(string prompt)
{
    Console.Write(prompt + ": ");
    string s = Console.ReadLine();
    try
    {
        return int.Parse(s);
    }
    catch(FormatException fex)
    {
        Console.WriteLine("Poikkeus:" + fex);
        return 0;
    }
}

int PromptForInt(string prompt)
{
    bool onnistui = false;
    int result = 0;
    while (!onnistui)
    {
        Console.Write(prompt + ": ");
        string s = Console.ReadLine();
        onnistui = int.TryParse(s, out result);
    }
    return result;
}

void ArvausPeli()
{
    const int maxValue = 50;
    Console.WriteLine($"Arvaa luku 1-{maxValue}");
    int secret = new Random().Next(maxValue) + 1;
    Console.WriteLine("Salainen " + secret);
    int guess = 0, numGuesses = 0;
    while (true)  //(guess != secret)
    {
        /*
        Console.Write("Arvauksesi: ");
        string guessString = Console.ReadLine();
        guess = int.Parse(guessString);
        */
        guess = PromptForInt("Arvauksesi");
        /*
        int[] valids = [3,6,7];
        if (valids.Contains(guess))
        {
            Console.WriteLine("Verrattu useampaan arvoon");
        }
        */
        if ((guess < 1) || (guess > maxValue))
        {
            Console.WriteLine("Paha arvaus");
            continue;
        }
        numGuesses = numGuesses + 1;  //numGuesses+=1, numGuesses++;
        if (guess == secret) break;
        if (guess < secret)
        {
            Console.WriteLine("Liian pieni");
        }
        if (guess > secret)
        {
            Console.WriteLine("Liian iso");
        }
    }
    Console.WriteLine("Oikein meni, tarvitsit " + numGuesses + " arvausta");
    Console.WriteLine(string.Format("Oikein formatoituna, arvauksia {0}", numGuesses));
    Console.WriteLine($"Oikein interpoloitu, arvauksia {numGuesses}");
}

int MuutaArvo(ref int a)
{
    Console.WriteLine("Sain arvon " + a);
    a++;
    Console.WriteLine("Muutin arvoa " + a);
    return 3;
}

void RefTest()
{
    int arvo = 53;
    MuutaArvo(ref arvo);
    Console.WriteLine("Nyt arvo on " + arvo);
}

void TestIt(object o)
{
    Console.WriteLine("Testi: " + o);
}

void TestPerson(Person p)
{
    Console.WriteLine("Test person: " + p.Name);
    if (p is Customer)
    {
        Customer c = p as Customer;
        Console.WriteLine("Ostot " + c.Purchases);
    }
    else Console.WriteLine("Ei ole asiakas");
}

//ArraysList();
//ArvausPeli();

/*
string s = null;
int? a = null;
Nullable<int> c = new Nullable<int>();
a = 4;
*/

//Car car = new Car();


void PersonTests()
{
    Person p = new Person("Jussi");
    //p.name = "Jussi";
    //p.Name = "Jyrki";
    //p.Name = "";
    //p.Name = null;
    p.Email = "jyrki@koe.com";
    p.Email = null;
    //p.Birthday = DateOnly.Parse("15.8.2000");
    //p.BirthdayString = "16.9.2001";
    //p.Birthday = null;
    //p.Birthday = DateOnly.Parse("24.12.2026");
    p.BirthdayString = "13.5.2000";
    p.BirthdayString = null;
    //Console.WriteLine(p.Name + "," + p.Email+","+p.BirthdayString+", Age="+p.Age);
    Person p2 = new Person("Teppo", "teppo@koe.com", DateOnly.Parse("11.11.2011"));
    //Console.WriteLine(p2.Name + "," + p2.Email + "," + p2.BirthdayString + ", Age=" + p2.Age);

    TestIt(p);
    TestIt(p2);

    Person p3 = new Person("Matti", "matti@koe.com", "12.12.1992");
    Console.WriteLine(p3.Name + "," + p3.Email + "," + p3.BirthdayString + ", Age=" + p3.Age);

    Console.WriteLine(p3);


    Customer c = new Customer("Aimo Asiakas", 4300);
    // c.Purchases = 43;
    //Console.WriteLine(c);
    TestIt(c);
    TestIt(DateTime.Now);
    TestIt("Terve maailma");


    TestPerson(p);
    TestPerson(c);

}

//PersonTests();

void MakePurchase(IBuyer o,double amount)
{
    string s = o.Buy(amount);
    Console.WriteLine("Kuitti: " + s);
}


Customer cust = new Customer("Antero", 3000);
Company comp = new Company() { Name = "Acme", Purchases = 4000 };

MakePurchase(cust, 200);
MakePurchase(comp, 300);

void PrintPrice(double net, double vat, Calculator calcTotal)
{
    double total = calcTotal(net, vat);
    double vatAmount = total - net;
    Console.WriteLine($"{net}+ALV {vatAmount} = ${total}");
}

PrintPrice(100, 25.5,(a,b) => a+a*b/100);
PrintPrice(200, 0.255,(a,b) => a+a*b);
PrintPrice(300, 71.5, (a,b) => a+b);

delegate double Calculator(double a, double b);
