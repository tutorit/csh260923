void Variables()
{
    Console.WriteLine("Hello, World!");

    int a = 32;
    a = 54;
    Int32 b = 64; // int ja Int32 ovat synonyymit

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

int PromptForInt(string prompt)
{
    Console.Write(prompt + ": ");
    string s = Console.ReadLine();
    return int.Parse(s);
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

//ArraysList();
ArvausPeli();
