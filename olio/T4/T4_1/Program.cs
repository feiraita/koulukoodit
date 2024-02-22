// See https://aka.ms/new-console-template for more information
using T4_1;

Opettaja opettaja1 = new Opettaja("Olli Luukas");
Opettaja opettaja2 = new Opettaja("Olive Rudge");
Opettaja opettaja3 = new Opettaja("Opettaja A");

Opintojakso opintojakso1 = new Opintojakso("Algebra");
opintojakso1.LisaaOpettaja(opettaja1);
opintojakso1.LisaaOpettaja(opettaja3);

Opintojakso opintojakso2 = new Opintojakso("Ruotsi 4");
opintojakso2.LisaaOpettaja(opettaja2);

Oppilas oppilas1 = new Oppilas("Oppilas1");
Oppilas oppilas2 = new Oppilas("Oppilas2");

oppilas1.LisaaOpintojakso(opintojakso1);
oppilas1.LisaaOpintojakso(opintojakso2);

oppilas2.LisaaOpintojakso(opintojakso2);

List<Oppilas> oppilaat = new List<Oppilas>();
oppilaat.Add(oppilas1);
oppilaat.Add(oppilas2);

Console.WriteLine(oppilaat);

Console.Write("Syötä oppilaan nimi: ");
string nimi = Console.ReadLine();

if (!string.IsNullOrEmpty(nimi))
{
    foreach (var oppilas in oppilaat)
    {
        if (oppilas.Nimi == nimi)
        {
            Console.WriteLine(oppilas);
            break;
        }
    }
}
