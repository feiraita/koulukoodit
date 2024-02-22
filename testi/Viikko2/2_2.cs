// See https://aka.ms/new-console-template for more information

List<string> lista = new List<string>();

var ohje = "0. Lopetus\n1. Lisää listaan\n2. Tulosta lista\n3. Poista listasta";
Console.WriteLine(ohje);
var komento = Console.ReadLine(); 

while (!komento.StartsWith("0"))
{
    switch(komento)
    {
        case "1":
            Console.WriteLine("Valitsit komennon 1");
            Console.Write("Mitä lisätään: ");
            var teksti = Console.ReadLine();
            lista.Add(teksti);
            break;

        case "2":
            Console.WriteLine("Valitsit komennon 2");
            Console.WriteLine("Tulostetaan koko lista: ");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(i + ". " + lista[i]);
            }
            break;

        case "3":
            Console.WriteLine("Anna poistettava indeksi");
            var t = Console.ReadLine();
            var index = int.Parse(t);
            lista.RemoveAt(index);
            break;

        default:
            break;
    }
    Console.WriteLine(ohje);
    komento = Console.ReadLine();   
}