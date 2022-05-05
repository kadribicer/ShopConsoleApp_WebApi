using Shop.ConsoleApp.Entities;

namespace Shop.ConsoleApp.Services.Abstract
{
    public interface IDiscountService
    {
        /// <summary>
        /// Method where discounts are applied according to user and product type
        /// </summary>
        /// <param name="user">User information</param>
        /// <param name="items">Items on invoice</param>
        /// <returns>Returns a model of type Invoice.</returns>
        Invoice ApplyDiscount(User user, List<Item> items);

        /// <summary>
        /// A method that returns the total price of products without any discount
        /// </summary>
        /// <param name="items">Items on invoice</param>
        /// <returns>double</returns>
        double GetTotalPrice(List<Item> items);

        /// <summary>
        /// A method that returns the total price of grocery items
        /// </summary>
        /// <param name="items">Items on invoice</param>
        /// <returns>double</returns>
        double GetGroceriesPrice(List<Item> items);

        /// <summary>
        /// It is a method that makes discounts according to the user type and the discounts earned on products other than grocery products, and makes a 5 dollar discount from every 100 dollars in the remaining amount. Final fee returns.
        /// </summary>
        /// <param name="user">User information</param>
        /// <param name="groceriesPrice">Grocery amount</param>
        /// <param name="otherPrice">Amount other than groceries</param>
        /// <returns>double</returns>
        double GetDiscountByUserType(User user, double groceriesPrice, double otherPrice);

        /// <summary>
        /// The method that gives you $5 off every $100
        /// </summary>
        /// <param name="total">Total price</param>
        /// <returns>double</returns>
        double FiveDollarDiscountForEveryHundredDollars(double total);

        /// <summary>
        /// A method that returns information in string type in order to be able to read the resulting invoice on the console screen more easily.
        /// </summary>
        /// <param name="invoice">Invoice</param>
        /// <returns></returns>
        string InvoiceReturnString(Invoice invoice);
    }
}