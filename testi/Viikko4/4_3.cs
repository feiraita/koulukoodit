// Program.cs
using Viikko4_3;

Console.WriteLine("Luokat yhdessä");

//objekti
Author a = new Author();
Book b = new Book();

a.Name = "A.Kivi";
b.Title = "7 bros";
b.Author = a;

Console.WriteLine(a.Name);
Console.WriteLine(b.Title);
Console.WriteLine(b.Author.Name);

Car car  = new Car(4.2);
// Engine engine = new Engine();
Person driver = new Person();
driver.Name = "Senna";

car.Driver = driver;
car.Model = "Bentley";
Console.WriteLine(car);