using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IToastNotification _notification;

        public CategoryController(ApplicationDbContext dbcontext, IToastNotification notification)
        {
            _dbcontext = dbcontext;
            _notification= notification; ;
        }
        [HttpGet]

        public IActionResult CategoryList()
        {
            var _categoryList = _dbcontext.Categories.ToList();
            if(_categoryList.Count<=0)
                _notification.AddWarningToastMessage("no category found");


            return View(_categoryList);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            _notification.AddWarningToastMessage("you will add category");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(Category category)
        {
            _notification.AddWarningToastMessage("you will add category");
            if (ModelState.IsValid)
            {
                _dbcontext.Categories.Add(category);
                _dbcontext.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }
    }
}
