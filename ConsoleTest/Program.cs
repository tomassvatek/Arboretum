using Arboretum.Core.Models;
using Arboretum.Core.Repositories;
using Arboretum.Core.Services;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArboretumContext ctx = new ArboretumContext();

            using(UnitOfWork unitOfWork = new UnitOfWork(ctx))
            {
                TreeService service = new TreeService(unitOfWork);
                var trees = service.GetTrees();
                foreach (var tree in trees)
                {
                    Console.WriteLine(tree.Id);
                }
            }

            Console.ReadKey();
        }
    }
}
