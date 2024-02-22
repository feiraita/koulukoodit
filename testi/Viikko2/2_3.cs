// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("StringBuilder");

var sb = new StringBuilder();
sb.Append("One");
sb.Append("Two");
var teksti = sb.ToString();

Console.WriteLine(teksti);

var sb2 = new StringBuilder();
sb.Append("Three");
sb.Append("Four");
var teksti2 = sb2.ToString();

Console.WriteLine(teksti2);