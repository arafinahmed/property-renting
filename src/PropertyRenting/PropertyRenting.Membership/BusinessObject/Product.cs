namespace PropertyRenting.Membership.BusinessObject
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
    }
}