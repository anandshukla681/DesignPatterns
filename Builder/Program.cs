// See https://aka.ms/new-console-template for more information
using Builder;

Console.Title = "BUilder";
Console.WriteLine("Hello, World!");
var garage = new Garage();
garage.Construct(new MiniBuilder());
garage.Show();
Console.ReadKey();