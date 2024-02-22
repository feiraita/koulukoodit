Console.WriteLine("Kuinka vanha olen?");

Console.Write("Anna päivä: ");
var pv = int.Parse(Console.ReadLine());

Console.Write("Anna kuukausi: ");
var kk = int.Parse(Console.ReadLine());

Console.Write("Anna vuosi: ");
var vv = int.Parse(Console.ReadLine());

var syntyma = new DateTime(vv, kk, pv);

var ika = DateTime.Now - syntyma;
Console.WriteLine(Math.Floor(ika.Days / 365.25) + "v");