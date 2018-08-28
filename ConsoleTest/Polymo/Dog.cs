using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.Polymo
{
    public class Dog : Animal
    {
        public Dog( AnimalType type ) : base( type )
        {
        }

        public override void Talk( )
        {
            Console.WriteLine( "Haf haf" );
        }
    }
}
