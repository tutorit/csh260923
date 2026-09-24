using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    internal class Customer : Person
    {
        public double Purchases { get; private set; }

        public Customer(string name, double purchases) :base(name)
        {
            Purchases = purchases;
        }

        public override string ToString()
        {
            return Name + " on ostanut " + Purchases + " eurolla";
        }
    }
}
