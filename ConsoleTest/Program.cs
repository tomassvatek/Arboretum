using Arboretum.Core.Models;
using Arboretum.Core.Repositories;
using Arboretum.Core.Services;
using Arboretum.Core.WebServices;
using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main( string[] args )
        {
            RestService rest = new RestService();
            rest.ReadManyAsync( ).Wait();

            Console.ReadKey( );
        }
    }
}
