using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class DiscountFacade
    {
        readonly OrderService orderService = new();
        CustomerDiscountBaseService customerDiscountBaseService = new();
        DayOfWeekFactorDiscountService dayOfWeekFactorDiscountService = new();

        public double CalculateDiscountPercentage(int customerId)
        {
            if(!orderService.HasEnoughOrders(customerId))
            {
                return 0;
            }
            return customerDiscountBaseService.CalculateDiscountBase(customerId) * dayOfWeekFactorDiscountService.CalculateDayOfWeekFactor();
        }
    }

    public class OrderService
    {
        public OrderService() { }

        internal bool HasEnoughOrders(int cutomerId)
        {
            throw new NotImplementedException();
        }
    }

    public class CustomerDiscountBaseService
    {
        internal int CalculateDiscountBase(int customerId)
        {
            return 10;
        }
    }

    public class DayOfWeekFactorDiscountService
    {
        public DayOfWeekFactorDiscountService() { }

        public int CalculateDayOfWeekFactor()
        {
            return 10;
        }
    }
}
