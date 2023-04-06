using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public abstract class Menu
    {
        protected ICoupon _coupon;

        public abstract int CalculatePrice();
        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
    }

    public interface ICoupon
    {
        int CouponValue { get; }
    }

    public class NoCoupon : ICoupon
    {
        public int CouponValue => 0;
    }
    public class NewYearCoupn : ICoupon
    {
        public int CouponValue => 5;
    }

    public class VegMenu : Menu
    {
        public VegMenu(ICoupon coupon) : base(coupon)
        {

        }
        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    public class MeatMenu : Menu
    {
        public MeatMenu(ICoupon coupon) : base(coupon)
        {

        }
        public override int CalculatePrice()
        {
            return 100 - _coupon.CouponValue;
        }
    }

}
