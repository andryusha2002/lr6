using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MainPage(User user)
        {
            if (user.Age >= 16)
            {
                TempData["Quantity"] = user.Age;
                return RedirectToAction("OrderPage");
            }
            else
            {
                return Content("Вибачте, ви повинні бути старші за 16 років для замовлення товарів.");
            }
        }

        [HttpGet]
        public IActionResult OrderPage()
        {
            if (TempData["Quantity"] == null)
            {
                return RedirectToAction("MainPage");
            }
            ViewBag.Quantity = TempData["Quantity"];
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmOrder(Product product)
        {
            return View("OrderConfirmation", product);
        }
    }
}





