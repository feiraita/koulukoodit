// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Tehtävä 1 Osio 1");
var i = 1;
double summa = 0;
var lista = new List<double>();

Console.Write("Anna lukumäärä: ");
var lukumaara = Console.ReadLine();
var maara = int.Parse(lukumaara);

if (maara == 0)
{
    Console.WriteLine("Syötit nollan :(");
}

else
{
    while (maara >= i)
    {
        Console.Write("Anna luku: ");
        var vast = Console.ReadLine();
        var num = double.Parse(vast);
        lista.Add(num);

        summa += num;
        i++;
    }

    Console.WriteLine($"Lukujen keskiarvo on {summa / maara}");
    Console.WriteLine($"Lukuja oli {maara}");

    Console.WriteLine("Syötetyt luvut ovat: ");

    foreach (int num in lista)
    {
        Console.WriteLine(num.ToString());
    }
}