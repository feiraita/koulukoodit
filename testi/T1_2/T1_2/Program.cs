// See https://aka.ms/new-console-template for more information
Console.WriteLine("Tehtävä 1 Osio 2");

Console.Write("Anna 1. luku: ");
var vast1 = Console.ReadLine();
var luku1 = int.Parse(vast1);

Console.Write("Anna 2. luku: ");
var vast2 = Console.ReadLine();
var luku2 = int.Parse(vast2);

PlusTaiMinus(luku1, luku2);

void PlusTaiMinus(int a, int b)
{
    if(a < b)
    {
        var vastaus = a - b;
        Console.WriteLine($"{a} - {b} = {vastaus}");
    }
    else
    {
        var vastaus = a + b;
        Console.WriteLine($"{a} + {b} = {vastaus}");
    }
}