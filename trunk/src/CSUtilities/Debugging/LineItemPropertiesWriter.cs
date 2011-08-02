using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CommerceServer.Runtime.Orders;

namespace CSUtilities.Debugging
{
    public class LineItemPropertiesWriter
    {
        private readonly TextWriter _writer;

        public LineItemPropertiesWriter(TextWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");

            _writer = writer;
        }

        public void Write(OrderGroup order)
        {
            Write(order.OrderForms[0]);
        }

        public void Write(OrderForm orderForm)
        {
            Write(orderForm.LineItems);
        }

        public void Write(LineItemCollection lineItems)
        {
            foreach (LineItem lineItem in lineItems)
            {
                Write(lineItem);
            }
        }

        public void Write(LineItem lineItem)
        {
            _writer.WriteLine("- Product {0}", lineItem.ProductId);

            foreach (var propertyInfo in 
                lineItem.GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(x => x.GetIndexParameters().Length == 0))
            {
                _writer.WriteLine("---- {0} = {1}", propertyInfo.Name, propertyInfo.GetValue(lineItem, null));
            }

            foreach (string property in lineItem)
                _writer.WriteLine("---- {0} = {1}", property, lineItem[property]);

            _writer.WriteLine();
        }
    }
}