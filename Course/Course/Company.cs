using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    internal interface IBuyer
    {
        public string Buy(double amount);
    }

    internal class Company :IBuyer
    {
        public string Name { get; set; }
        public double Purchases { get; set;  }

        public string Buy(double amount)
        {
            return "Yritysosto " + amount + "EUR, ALV " + amount * 0.255;
        }
    }
}
