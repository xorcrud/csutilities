namespace CSUtilities
{
    /// <summary>
    /// Example on how you can extend the generated class by creating a partial class of name "MetadataDefinitions".
    /// </summary>
    public partial class MetadataDefinitions
    {
        public class CustomEntity
        {
            public const string EntityName = "CustomEntity";

            public class Properties
            {
                public const string SomeProperty = "SomeProperty";
            }
        }

        public partial class Address
        {
            public partial class Properties
            {
                public const string FirstName = "FirstName";
                public const string LastName = "LastName";
                public const string Line1 = "Line1";
                public const string Line2 = "Line2";

                static partial void AddToAll(System.Action<string> addProperty)
                {
                    addProperty(FirstName);
                    addProperty(LastName);
                    addProperty(Line1);
                    addProperty(Line2);
                }
            }
        }

        public partial class Product
        {
            public partial class Relationships
            {
                public const string OtherRelationship = "OtherRelationship";

                static partial void AddToAll(System.Action<string> addRelationship)
                {
                    addRelationship(OtherRelationship);
                }
            }
        }        
    }
}