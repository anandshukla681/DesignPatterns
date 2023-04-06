using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryIdentifier;
        public CountryDiscountService(string country)
        {
            _countryIdentifier = country
;
        }
        public override int DiscountPercentage
        {
            get
            {
                return _countryIdentifier switch
                {
                    "BE" => 20,
                    _ => 0,
                };
            }
        }
    }
    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;
        public CodeDiscountService(Guid code)
        {
            _code = code;
        }
        public override int DiscountPercentage => 20;
    }
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }
    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryIdentifier;
        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }
    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;
        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }
        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }
}
