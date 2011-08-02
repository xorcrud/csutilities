using System;
using System.Collections;
using System.IO;
using System.Linq;
using Microsoft.Commerce.Contracts;

namespace CSUtilities.Debugging
{
    public class CommerceEntityWriter
    {
        private readonly TextWriter _writer;

        public CommerceEntityWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public void Write(ICommerceEntity entity)
        {
            if (_writer == null) return;

            if (entity == null)
                _writer.WriteLine("<null>");

            OutputInternal(entity, String.Empty);
        }

        private void OutputInternal(ICommerceEntity entity, string linePrefix)
        {
            if (entity == null) return;

            _writer.Write(linePrefix);
            _writer.WriteLine("Model = {0}", entity.ModelName);

            foreach (var property in entity.Properties)
            {
                _writer.Write(linePrefix);

                if (property.Value is CommerceRelationshipList)
                {
                    _writer.WriteLine(property.Key);

                    foreach (var relationShipEntity in (property.Value as CommerceRelationshipList).Select(x => x.Target))
                        OutputInternal(relationShipEntity, AppendLinePrefix(linePrefix));
                }
                else if (property.Value is CommerceRelationship)
                {
                    _writer.WriteLine(property.Key);

                    OutputInternal((property.Value as CommerceRelationship).Target, AppendLinePrefix(linePrefix));
                }
                else
                {
                    _writer.WriteLine(
                        "{0} = {1} ({2})",
                        property.Key,
                        WriteValue(property.Value),
                        property.Value != null ? property.Value.GetType().FullName : "<null>");
                }
            }

            _writer.WriteLine();
        }

        private static string WriteValue(object value)
        {
            if (value == null) return "<null>";
            if (value is string) return value.ToString();

            if (value is IEnumerable)
            {
                return
                    String.Join(", ",
                                (value as IEnumerable)
                                    .OfType<object>()
                                    .Select(x => x.ToString())
                                    .ToArray());
            }

            return value.ToString();
        }

        private static string AppendLinePrefix(string linePrefix)
        {
            return String.Concat(linePrefix.Trim(), new string('-', 3), " ");
        }        
    }
}