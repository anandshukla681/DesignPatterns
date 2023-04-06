using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Car
    {
        private readonly List<string> _carParts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddParts(string carParts)
        {
            _carParts.Add(carParts);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var part in _carParts)
            {
                sb.Append($"Car of type {_carType} has part {part}");
            }
            return sb.ToString();
        }
    }

    public abstract class CarBuilder
    {
        public Car Car { get; private set; }
        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }
        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }

    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder() : base("Mini")
        {

        }
        public override void BuildEngine()
        {
            Car.AddParts("V8");
        }

        public override void BuildFrame()
        {
            Car.AddParts("3 sided door");
        }
    }

    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder() : base("BMW")
        {

        }
        public override void BuildEngine()
        {
            Car.AddParts("BMW Engine");
        }

        public override void BuildFrame()
        {
            Car.AddParts("BMW Frame");
        }
    }


    public class Garage
    {
        CarBuilder? _builder;
        public Garage()
        {
        }
        public void Construct(CarBuilder builder)
        {
            _builder = builder;
            _builder?.BuildEngine();
            _builder?.BuildFrame();
        }

        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }
    }

}
