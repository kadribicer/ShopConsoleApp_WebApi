using Shop.ConsoleApp.Entities;
using Shop.ConsoleApp.Services.Abstract;
using Shop.ConsoleApp.Services.Concrete;

IDiscountService discountService = new DiscountService();
var resut = 
    discountService.ApplyDiscount(
    new User(UserType.Employee, new DateTime(day: 12, month: 2, year: 2015)),
    new List<Item>
    {
        new Item(ItemType.Grocery, 15),
        new Item(ItemType.Grocery, 22),
        new Item(ItemType.Grocery, 7),
        new Item(ItemType.Other, 150),
        new Item(ItemType.Other, 232),
        new Item(ItemType.Other, 87),
        new Item(ItemType.Other, 36)}
    );

Console.WriteLine(discountService.InvoiceReturnString(resut));
Console.ReadLine();