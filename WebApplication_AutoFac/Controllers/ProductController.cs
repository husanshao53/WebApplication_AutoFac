using AutoFac_Demo2.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_AutoFac.Controllers
{
    public class ProductController : Controller
    {
        #region
        //readonly IProductRepository repository;
        ////构造器注入
        //public ProductController(IProductRepository repository)
        //{
        //    this.repository = repository;
        //}
        #endregion
        public IProductRepository _productRepository { get; set; }
        public IUserRepository _userRepository { get; set; }
        // GET: /Product/
        public ActionResult Index()
        {
            var data = _productRepository.GetAll();
            ViewBag.User = _userRepository.GetAll();
            return View(data);
        }



    }
}