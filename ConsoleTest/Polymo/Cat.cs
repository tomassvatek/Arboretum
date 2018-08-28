using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Polymo
{
    public class Cat : Animal
    {
        public Cat( AnimalType type ) : base( type )
        {
        }

        public override void Talk( )
        {
            Console.WriteLine( "Mnau" );
        }
    }
}
