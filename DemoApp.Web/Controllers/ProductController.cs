using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoApp.Business.Product;
using DemoApp.Common.Common;
using DemoApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductBusiness business;
        private readonly IMapper mapper;

        public ProductController(IMapper _mapper, IProductBusiness _business)
        {
            business = _business;
            mapper = _mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var _result = business.GetAll();
            IEnumerable<ProductViewModel> result = mapper.Map<IEnumerable<ProductViewModel>>(_result);
            return View(result);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet] // for jQuery DataTable
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product data = mapper.Map<Product>(model);
                var result = business.InsertUpdate(data);
                HttpContext.Session.SetInt32("ErrorCode", result.ErrorCode);
                HttpContext.Session.SetString("Message", result.Message);

                if (result.ErrorCode.Equals(0))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var _result = business.PopulateById(id);

            if (_result == null)
            {
                HttpContext.Session.SetInt32("ErrorCode", 1);
                HttpContext.Session.SetString("Message", "Data doesnot Exists!");
                return RedirectToAction("Index");
            }
            ProductViewModel result = mapper.Map<ProductViewModel>(_result);
            return View(result);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind] ProductViewModel model)
        {
            if ((id != model.PId) || (id == null))
            {
                return View(model);
            }
            if (ModelState.IsValid)
            {
                Product data = mapper.Map<Product>(model);
                var result = business.InsertUpdate(data);
                HttpContext.Session.SetInt32("ErrorCode", result.ErrorCode);
                HttpContext.Session.SetString("Message", result.Message);

                if (result.ErrorCode.Equals(0))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var _result = business.PopulateById(id);
            ProductViewModel result = mapper.Map<ProductViewModel>(_result);
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var result = business.Delete(id);
            HttpContext.Session.SetInt32("ErrorCode", result.ErrorCode);
            HttpContext.Session.SetString("Message", result.Message);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var _result = business.PopulateById(id);
            ProductViewModel result = mapper.Map<ProductViewModel>(_result);
            return View(result);
        }

    }
}
