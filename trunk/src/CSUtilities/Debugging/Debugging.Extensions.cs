using System.IO;
using Microsoft.Commerce.Contracts;
using Microsoft.CommerceServer.Runtime.Orders;

namespace CSUtilities.Debugging
{
    public static class DebuggingExtensions
    {
        public static void Output(this ICommerceEntity entity, TextWriter writer)
        {
            new CommerceEntityWriter(writer).Write(entity);
        }

        public static void CheckWriteOrderErrors(this OrderGroup order, TextWriter writer)
        {
            new OrderGroupErrorWriter(writer).Write(order);
        }

        public static void WriteLineItemProperties(this OrderGroup order, TextWriter writer)
        {
            new LineItemPropertiesWriter(writer).Write(order);
        }
    }
}