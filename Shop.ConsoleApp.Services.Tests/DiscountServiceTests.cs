using Shop.ConsoleApp.Entities;
using Shop.ConsoleApp.Services.Abstract;
using Shop.ConsoleApp.Services.Concrete;
using System;
using System.Collections.Generic;
using Xunit;

namespace Shop.ConsoleApp.Services.Tests
{
    public class DiscountServiceTests
    {
        private readonly IDiscountService _discountService;
        private readonly List<Item> items;
        public DiscountServiceTests()
        {
            _discountService = new DiscountService();
            items = new List<Item>
            {
                new Item(ItemType.Grocery, 15),
                new Item(ItemType.Grocery, 38),
                new Item(ItemType.Other, 130),
                new Item(ItemType.Other, 205),
            };
        }

        /// <summary>
        /// Test method return null if user model is empty
        /// </summary>
        [Fact]
        public void ApplyDiscount_Null_User_Return_Null()
        {
            var result = _discountService.ApplyDiscount(null, items);
            Assert.Null(result);
        }

        /// <summary>
        /// If the products list is empty, the test method returns null.
        /// </summary>
        [Fact]
        public void ApplyDiscount_Null_ItemList_Return_Null()
        {
            var user = new User(UserType.Employee, new DateTime(day: 12, month: 2, year: 2020));
            var result = _discountService.ApplyDiscount(user, new List<Item>());
            Assert.Null(result);
        }

        /// <summary>
        /// The method in which all transactions related to invoice, discount and invoice are tested
        /// </summary>
        [Fact]
        public void ApplyDiscount_Return_Invoice()
        {
            var user = new User(UserType.Employee, new DateTime(day: 12, month: 2, year: 2020));
            var result = _discountService.ApplyDiscount(user, items);
            var invoiceResult = Assert.IsAssignableFrom<Invoice>(result);
            Assert.NotNull(invoiceResult);
            Assert.Equal(110.5, invoiceResult.DiscountPrice);
            Assert.Equal(277.5, invoiceResult.FinalPrice);
            Assert.Equal(53, invoiceResult.GroceryPrice);
            Assert.Equal(335, invoiceResult.OtherPrice);
            Assert.Equal(388, invoiceResult.TotalPrice);
        }

        /// <summary>
        /// The method by which employee discount is tested
        /// </summary>
        [Fact]
        public void GetDiscountByUserType_Employee_Verify()
        {
            var user = new User(UserType.Employee, new DateTime(day: 12, month: 2, year: 2020));
            var result = _discountService.GetDiscountByUserType(user, 53, 335);
            Assert.Equal(277.5, result);
        }

        /// <summary>
        /// The method by which affiliate discount is tested
        /// </summary>
        [Fact]
        public void GetDiscountByUserType_Affiliate_Verify()
        {
            var user = new User(UserType.Affiliate, new DateTime(day: 12, month: 2, year: 2020));
            var result = _discountService.GetDiscountByUserType(user, 53, 335);
            Assert.Equal(339.5, result);
        }

        /// <summary>
        /// The method by which customer discount is tested
        /// </summary>
        [Fact]
        public void GetDiscountByUserType_Customer_Verify()
        {
            var user = new User(UserType.Customer, new DateTime(day: 12, month: 2, year: 2021));
            var result = _discountService.GetDiscountByUserType(user, 53, 335);
            Assert.Equal(373, result);
        }

        /// <summary>
        /// The method by which old customer discount is tested
        /// </summary>
        [Fact]
        public void GetDiscountByUserType_OldCustomer_Verify()
        {
            var user = new User(UserType.Customer, new DateTime(day: 12, month: 2, year: 2015));
            var result = _discountService.GetDiscountByUserType(user, 53, 335);
            Assert.Equal(356.25, result);
        }

        /// <summary>
        /// It is the test method that validates the total price of all products in the products list.
        /// </summary>
        [Fact]
        public void GetTotalPrice_Verify()
        {
            var result = _discountService.GetTotalPrice(items);
            Assert.Equal(388, result);
        }

        /// <summary>
        /// A test method that simulates the scenario where the total price of all products in the products list is not verified.
        /// </summary>
        [Fact]
        public void GetTotalPrice_NotVerify()
        {
            var result = _discountService.GetTotalPrice(items);
            Assert.NotEqual(200, result);
        }

        /// <summary>
        /// It is the test method that confirms the total price of all grocery products in the products list.
        /// </summary>
        [Fact]
        public void GetGroceriesPrice_Verify()
        {
            var result = _discountService.GetGroceriesPrice(items);
            Assert.Equal(53, result);
        }

        /// <summary>
        /// A test method that simulates the scenario where the total price of all grocery items in the products list is not verified.
        /// </summary>
        [Fact]
        public void GetGroceriesPrice_NotVerify()
        {
            var result = _discountService.GetGroceriesPrice(items);
            Assert.NotEqual(48, result);
        }

        /// <summary>
        /// Over $1500 total, there should be a discount of $75 as the discount should be $5 for every $100, the test method simulates this discount.
        /// </summary>
        [Fact]
        public void FiveDollarDiscountForEveryHundredDollars_Verify()
        {
            var result = _discountService.FiveDollarDiscountForEveryHundredDollars(1500);
            Assert.Equal(1425, result);
        }

        /// <summary>
        /// Over the $1500 total, there should be a $75 discount since the discount should be $5 on every $100, 
        /// but the test method simulates the scenario where this discount is not validated.
        /// </summary>
        [Fact]
        public void FiveDollarDiscountForEveryHundredDollars_NotVerify()
        {
            var result = _discountService.FiveDollarDiscountForEveryHundredDollars(1500);
            Assert.NotEqual(1420, result);
        }
    }
}