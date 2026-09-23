/*
Console.WriteLine("Hello, World!");

int a = 32;
a = 54;
Int32 b = 64;

string tx = "Hello";
tx += " maailma";
tx += a;
*/
//Console.WriteLine(tx);

Console.WriteLine("Arvaa luku 1-100");
int secret = new Random().Next(100) + 1;
Console.WriteLine("Salainen " + secret);
int guess = 0, numGuesses=0;
while (true)  //(guess != secret)
{
    Console.Write("Arvauksesi: ");
    string guessString = Console.ReadLine();
    guess=int.Parse(guessString);
    if ((guess < 1) || (guess > 100))
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
Console.WriteLine("Oikein meni, tarvitsit "+numGuesses+" arvausta");
Console.WriteLine(string.Format("Oikein formatoituna, arvauksia {0}", numGuesses));
Console.WriteLine($"Oikein interpoloitu, arvauksia {numGuesses}");