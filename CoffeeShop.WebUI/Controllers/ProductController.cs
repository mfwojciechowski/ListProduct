using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.Domain.DbConc;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;


namespace CoffeeShop.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult Update(int productId, int productQuantity)
        {
            try
            {
                var product = productRepository.Values.First(p => p.ProductId == productId);
                product.Quantity = productQuantity;
                productRepository.Save(product);
                return Json(new { success = true, responseText = "Product updated" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = $"Error while updating product: {ex}" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ViewResult List()
        {
            
            return View(productRepository.Values);
        }

        [HttpGet]
        public ViewResult Edit(int productID)
        {
            Product product = productRepository.Values.FirstOrDefault(p => p.ProductId == productID);
            return View(product);
        }

        
       [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Save(product);
            }
           
            return RedirectToAction("List");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Save(product);
            }

            return RedirectToAction("List");
        }


        

    }
}