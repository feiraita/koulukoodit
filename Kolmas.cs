// See https://aka.ms/new-console-template for more information
// User input kokeilu

Console.WriteLine("Ehtolauseet");
Console.WriteLine("Anna numero 1-10");

var vastaus = Console.ReadLine();
var numero = int.Parse(vastaus);

if(numero < 5) 
{
    if(numero < 3)
    {
        Console.WriteLine("Alle 3");
    }
    else
    {
        Console.WriteLine("3-4");
    }
} 

else 
{
    Console.WriteLine("5 tai yli");
}