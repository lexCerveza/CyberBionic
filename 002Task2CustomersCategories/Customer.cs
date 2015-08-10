using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002Task2CustomersCategories
{
    class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override int GetHashCode()
        {
            return Id + Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var castedCustomer = (Customer) obj;
            if (castedCustomer == null)
            {
                return false;
            }
            //if (ReferenceEquals(castedCustomer, null))
            //{
            //    return false;
            //}

            return (Id == castedCustomer.Id) && (Name == castedCustomer.Name);
        }

        public override string ToString()
        {
            return String.Format("Id = {0}, Name = {1}", Id , Name);
        }
    }
}
