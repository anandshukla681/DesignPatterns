using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostService();
    }

    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }
    public interface IShippingCostService
    {
        decimal ShippingCost { get; }
    }

    public class BenlgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 30;
    }

    public class BelgiumShippingCostService : IShippingCostService
    {
        public decimal ShippingCost => 3.25M;
    }
    public class FranceShippingCostService : IShippingCostService
    {
        public decimal ShippingCost => 100.20M;
    }

    public class BengiumShoppingCartFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BenlgiumDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new BelgiumShippingCostService();
        }
    }

    public class FranceShoppingCartFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new FranceShippingCostService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;

        public ShoppingCart(IShoppingCartPurchaseFactory purchaseFactory)
        {
            _discountService = purchaseFactory.CreateDiscountService();
            _shippingCostService = purchaseFactory.CreateShippingCostService();
        }

        public void GetCost()
        {
            Console.WriteLine($"Total discount {_discountService.DiscountPercentage} " +
                $"and shipping cost {_shippingCostService.ShippingCost}");
        }
    }

}
