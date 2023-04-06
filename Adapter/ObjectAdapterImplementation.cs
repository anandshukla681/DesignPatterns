using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{

    public class CityFromExternalSystem
    {
        public string Name { get; }
        public string NickName { get; }
        public int Inhabitants { get; }
        public CityFromExternalSystem(string name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }

    }

    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antewarp", "'t stad", 5000);
        }
    }

    public class City
    {
        public string FullName { get; private set; }
        public long Inhabitants { get; private set; }
        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }
    public interface ICityAdapter
    {
        City GetCity();
    }

    public class CityAdapter : ICityAdapter
    {
        private readonly ExternalSystem _cityFromExternalSystem;

        public CityAdapter(ExternalSystem externalSystem)
        {
            _cityFromExternalSystem = externalSystem;
        }
        public City GetCity()
        {
            var city = _cityFromExternalSystem.GetCity();
            return new City($"{city.Name}-{city.NickName}", city.Inhabitants);
        }
    }

}
