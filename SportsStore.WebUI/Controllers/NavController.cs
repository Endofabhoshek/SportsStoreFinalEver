using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository productRepository;

        public NavController(IProductRepository repository)
        {
            productRepository = repository;
        }

        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categroies = productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);

            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";

            return PartialView(viewName, categroies);


        }
    }
}