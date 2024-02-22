// See https://aka.ms/new-console-template for more information
Console.WriteLine("Anna koodi: ");
var koodi = Console.ReadLine();
koodi = koodi.Trim();

if (koodi.Length == 9)
{
    var merkki = koodi.Substring(7, 1);
    var vuosi = koodi.Substring(5, 2);
    var tutkinto = koodi.Substring(0, 2);

    Console.WriteLine($"Aloitusvuosi on 20{vuosi}");

    if (merkki.ToLower() == "a")
    {
        Console.WriteLine("Syksy");
    }
    else if (merkki.ToLower() == "x")
    {
        Console.WriteLine("Kevät");
    }

    if (tutkinto.ToLower() == "in")
    {
        Console.WriteLine("Tutkinto on insinööri");
    }
}
