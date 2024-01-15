// See https://aka.ms/new-console-template for more information
// Kysyy nimen ja iän
Console.WriteLine("Hello, World!");
Console.Write("Toinen rivi");
Console.WriteLine("Ilman rivivaihtoa");

Console.Write("Anna nimesi: ");
var nimi = Console.ReadLine();

Console.Write("Anna ikäsi: ");
var ika = Console.ReadLine();
Console.WriteLine($"{ika} {nimi}");

var numero = int.Parse(ika);
Console.WriteLine("Ensi vuonna olet\n" + (numero + 1) + " vuotta vanha");