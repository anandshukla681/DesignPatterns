using Bridge;

Console.Title = "Bridge";
var noCoupon = new NoCoupon();
var oneDollorCoupon = new NewYearCoupn();
var vegMenu = new VegMenu(noCoupon);
var meatMenu = new MeatMenu(noCoupon);

Console.WriteLine($"VegMenu with nocoupn{vegMenu.CalculatePrice()}");

var vegMenu1 = new VegMenu(oneDollorCoupon);
var meatMenu1 = new MeatMenu(oneDollorCoupon);
Console.WriteLine($"VegMenu with coupon{vegMenu1.CalculatePrice()}");

Console.ReadLine();