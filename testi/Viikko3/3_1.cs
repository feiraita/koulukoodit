// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Runtime.Intrinsics.X86;
Console.WriteLine("Hello, World!");
/*
string nimi1;
int ika1;

string nimi2;
int ika2;

nimi1 = "Volvo";
ika1 = 20;

nimi2 = "Tesla";
ika2 = 1;

Console.WriteLine(nimi1 + " " + ika1);
Console.WriteLine(nimi2 + " " + ika2);

*/

Ajoneuvo auto1 = new Ajoneuvo("Volvo", 20);
// auto1.asetaNimi("Volvo");
// auto1.asetaIka(20);
// auto1.Ika = 20;

Ajoneuvo auto2 = new Ajoneuvo("Tesla", -2);
// auto2.asetaNimi("Tesla");
// auto2.asetaIka(-2);

List<Ajoneuvo> lista = [];
lista.Add(new Ajoneuvo("Volvo", 20));
lista.Add(new("Tesla", -2));

for(int i = 0; i <lista.Count; i++)
{
    Console.WriteLine(lista[i].Tiedot());
    Console.WriteLine(lista[i].Nimi);
    lista[i].Tulosta();
}

record Ajoneuvo2(string Nimi, int Ika);
/*
Console.WriteLine(auto1.Tiedot());
Console.WriteLine(auto2.Tiedot());

auto1.Tulosta();
auto2.Tulosta();
*/