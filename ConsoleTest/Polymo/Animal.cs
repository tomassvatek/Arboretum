using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Polymo
{
    public class Animal
    {
        public AnimalType Type { get; set; }
        public int Age { get; set; }

        public Animal( AnimalType type )
        {
            Type = type;
        }

        public virtual void Talk( )
        {
            Console.WriteLine("Universal animal talk");
        }
    }
}
