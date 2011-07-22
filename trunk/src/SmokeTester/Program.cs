using System;
using CSUtilities;

namespace SmokeTester
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var property in MetadataDefinitions.Address.Properties.All)
                Console.WriteLine(property);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
