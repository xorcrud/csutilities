using System;
using CommerceServer.Extensions;

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

            Console.WriteLine(MetadataDefinitions.CustomEntity.EntityName);
        }
    }
}
