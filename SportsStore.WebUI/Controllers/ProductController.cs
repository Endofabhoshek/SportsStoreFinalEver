using Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public int PageSize = 2;

        public ProductController(IProductRepository repository)
        {
            this.productRepository = repository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = productRepository.Products.Where(x => String.IsNullOrEmpty(category) ? true : (x.Category == category || x.Category == null)).OrderBy(p => p.Category).Skip((page - 1) * PageSize).Take(PageSize)
                ,
                PagingInfo = new PagingInfo() { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = category == null ? productRepository.Products.Count() : productRepository.Products.Where(x => x.Category == category).Count() },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}