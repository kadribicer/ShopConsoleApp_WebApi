namespace Shop.ConsoleApp.Entities
{
    public class Invoice
    {
        public double TotalPrice { get; set; }
        public double GroceryPrice { get; set; }
        public double OtherPrice { get; set; }
        public double DiscountPrice { get; set; }
        public double FinalPrice { get; set; }
    }
}