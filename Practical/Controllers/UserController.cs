using BussinessLogicInterface;
using DomainEntities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Practical.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private bool isSearch = false;
        private string searchValue = "";
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;

        }

        public IActionResult Users()
        {

            var overviewDto = new UserOverviewDto();
            isSearch = Convert.ToBoolean(TempData["isSearch"]);
            searchValue = Convert.ToString(TempData["searchValue"]);
            ViewBag.TextboxValue = string.IsNullOrEmpty(searchValue) ? "" : searchValue;
            if (isSearch && (!string.IsNullOrEmpty(searchValue)))
            {
                overviewDto = _userInterface.SearchData(searchValue);
                
            }
            else
            {
                overviewDto = _userInterface.GetList();
            }

            TempData["searchValue"] = "";
            TempData["isSearch"] = false;
            return View(overviewDto);
        }

        public IActionResult SearchData(string value)
        {
            TempData["searchValue"] = value;
            TempData["isSearch"] = true;
            return Json(true);
        }


    }
}
