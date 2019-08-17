using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository productRepository;

        public AdminController(IProductRepository product)
        {
            productRepository = product;
        }

        public ViewResult Index()
        {
            return View(productRepository.Products);
        }
    }
}