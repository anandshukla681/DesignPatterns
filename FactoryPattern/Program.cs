// See https://aka.ms/new-console-template for more information
using FactoryPattern;

Console.Title = "Factory Method";
var factories = new List<DiscountFactory>()
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE")
};

foreach (var fact in factories)
{
    var discountService = fact.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} " + $"coming from {discountService}");
}

Console.ReadLine();