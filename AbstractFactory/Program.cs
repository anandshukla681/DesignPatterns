// See https://aka.ms/new-console-template for more information
using AbstractFactory;

Console.WriteLine("Hello, World!");
ShoppingCart shoppingCart = new ShoppingCart(new BengiumShoppingCartFactory());
shoppingCart.GetCost();
Console.ReadKey();