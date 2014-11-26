using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsCloning
{
    public class HouseOwner
    {
        public string Name { get; set; }
        public Animal Pet { get; set; }

        public HouseOwner() { }
        public HouseOwner(string name, Animal pet)
        {
            Name = name;
            Pet = pet;
        }
    }
}
