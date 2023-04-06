using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class Person
    {
        public abstract string Name { get; }
        public abstract Person Clone(bool deepClone);
    }

    public class Employee : Person
    {
        public override string Name { get; }
        public Employee(string name, Manager manager)
        {
            Name = name;
        }

        public override Person Clone(bool deepClone)
        {
            if (deepClone)
            {
                return new Employee(Name, null);
            }
            return (Person)this.MemberwiseClone();
        }
    }

    public class Manager : Person
    {
        public override string Name { get; }
        public Manager(string name)
        {
            Name = name;
        }

        public override Person Clone(bool deepClone)
        {
            if (deepClone)
            {
                return new Manager(Name); ;
            }
            return (Person)this.MemberwiseClone();
        }
    }
}
