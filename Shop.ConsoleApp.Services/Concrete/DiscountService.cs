using Shop.ConsoleApp.Entities;
using Shop.ConsoleApp.Services.Abstract;

namespace Shop.ConsoleApp.Services.Concrete
{
    public class DiscountService : IDiscountService
    {
        #region Custom Methods
        public Invoice ApplyDiscount(User user, List<Item> items)
        {
            if (user == null || items.Count == 0)
                return null;

            var totalPrice = GetTotalPrice(items);
            var groceriesPrice = GetGroceriesPrice(items);
            var otherPrice = totalPrice - groceriesPrice;
            var discountPrice = totalPrice - GetDiscountByUserType(user, groceriesPrice, otherPrice);

            return new Invoice
            {
                TotalPrice = totalPrice,
                GroceryPrice = groceriesPrice,
                OtherPrice = otherPrice,
                DiscountPrice = discountPrice,
                FinalPrice = totalPrice - discountPrice,
            };
        }
        public double GetTotalPrice(List<Item> items)
        {
            double total = 0;
            items.ForEach(item => total += item.GetPrice());
            return total;
        }
        public double GetGroceriesPrice(List<Item> items)
        {
            double total = 0;
            items.ForEach(item => { total += item.GetItemType() == ItemType.Grocery ? item.GetPrice() : 0; });
            return total;
        }
        public double GetDiscountByUserType(User user, double groceriesPrice, double otherPrice)
        {
            double discountedPrice = 0;
            switch (user.GetUserType())
            {
                case UserType.Employee:
                    discountedPrice = otherPrice - (otherPrice * 0.30);
                    break;
                case UserType.Affiliate:
                    discountedPrice = otherPrice - (otherPrice * 0.10);
                    break;
                case UserType.Customer:
                    TimeSpan ts = user.GetJoinDate() - DateTime.Now;
                    if (Math.Abs(ts.Days) > 730)
                        discountedPrice = otherPrice - (otherPrice * 0.05);
                    else
                        discountedPrice = otherPrice;
                    break;
            }

            return FiveDollarDiscountForEveryHundredDollars(discountedPrice + groceriesPrice);
        }
        public double FiveDollarDiscountForEveryHundredDollars(double total) => total > 100 ? total - (Math.Floor(total / 100) * 5) : total;
        public string InvoiceReturnString(Invoice invoice)
        {
            return "Grocery Price: $" + invoice.GroceryPrice
                    + "\n" +
                    "Other Product Price: $" + invoice.OtherPrice
                    + "\n" +
                    "Total Price: $" + invoice.TotalPrice
                    + "\n" +
                    "Discount: $" + invoice.DiscountPrice
                    + "\n" +
                    "Final Price: $" + invoice.FinalPrice;
        }
        #endregion
    }
}