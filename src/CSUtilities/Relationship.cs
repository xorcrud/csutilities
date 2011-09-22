namespace CSUtilities
{
    /// <summary>
    /// Defines a Relationship for a given model. 
    /// </summary>
    public sealed class Relationship
    {
        /// <summary>
        /// Creates a new Relationship definition.
        /// </summary>
        /// <param name="name">The name of the Relationship.</param>
        /// <param name="model">The name of the Model returned in the Relationship.</param>
        public Relationship(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public string Name { get; private set; }
        public string Model { get; private set; }
    }
}