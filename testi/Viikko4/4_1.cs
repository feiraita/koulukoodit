// See https://aka.ms/new-console-template for more information
Console.WriteLine("Arvonta!");

List<int> lista = [];
var r = new Random();

for(int j = 0; j < 12; j++)
{
    lista.Clear();

    for (int i = 0; i < 7; i++)
    {
        var arvottu = r.Next(1, 41);

        while (lista.Contains(arvottu))
        {
            arvottu = r.Next(1, 41);
        }

        lista.Add(arvottu);
    }

    lista.Sort();

    for (int i = 0; i < 7; i++)
    {
        Console.Write(lista[i] + " ");
    }

    Console.WriteLine();
}
