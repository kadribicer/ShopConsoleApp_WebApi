using Microsoft.AspNetCore.Mvc;
using Shop.ConsoleApp.Entities;
using Shop.ConsoleApp.Services.Abstract;

namespace Shop.MVC.RESTfulApi.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region Veriables
        private readonly IDiscountService discountService;
        private readonly User user;
        private readonly List<Item> items;
        #endregion

        #region Constructor
        public HomeController(IDiscountService _discountService)
        {
            discountService = _discountService;
            user = new User(UserType.Employee, new DateTime(day: 12, month: 2, year: 2015));
            items = new List<Item>()
            {
                new Item(ItemType.Grocery, 15),
                new Item(ItemType.Grocery, 22),
                new Item(ItemType.Grocery, 7),
                new Item(ItemType.Other, 150),
                new Item(ItemType.Other, 232),
                new Item(ItemType.Other, 87),
                new Item(ItemType.Other, 36),
            };
        }
        #endregion

        #region Custom Methods
        [Route(""), HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult RedirectToSwaggerUi() => Redirect("/swagger");

        [HttpGet]
        [Route("GetInvoices")]
        public IActionResult GetInvoice()
        {
            try
            {
                var model = discountService.ApplyDiscount(user, items);
                return Ok(model);
            }
            catch
            {
                return NotFound("Server error, error occurred while processing request!");
            }
        }
        #endregion
    }
}