namespace Company.Products.Entities
{
    public class Product
    {
        public Product(string title, string description, decimal value, int quantity)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Value = value;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public int Quantity { get; private set; }

        public void Update(string title, string description, decimal value, int quantity)
        {
            Title = title;
            Description = description;
            Value = value;
            Quantity = quantity;
        }
    }
}
