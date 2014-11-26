using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsCloning
{
    public class House
    {
        public string Address { get; set; }

        public HouseOwner Owner { get; set; }

        public House() { }
        public House(string address, HouseOwner owner)
        {
            Address = address;
            Owner = owner;
        }

        public override string ToString()
        {
            return string.Format("House Address: {0}\n\tOwner Name: {1}\n\t\tPetName: {2}", Address, Owner.Name, Owner.Pet.Name);
        }
    }
}
