namespace BookStoreApp.Core.ValueObjects
{
    public class Category
    {
        public string Name { get; set; }

        public Category(string name)
        {
            //Guard or Exception check.
            Name = name;
        }

        public static Category Create(string value)
        {
            return new Category(value);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
