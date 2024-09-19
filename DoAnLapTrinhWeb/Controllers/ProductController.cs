using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLapTrinhWeb.Models;

namespace DoAnLapTrinhWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string sort, string search = "")
        {
            ShopDBContext db = new ShopDBContext();
            List<Product> pro = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            switch (sort)
            {
                case "MatDinh":
                    pro = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
                    break;
                case "TangDan":
                    pro = pro.OrderBy(row => row.Price).ToList();
                    break;
                case "GiamDan":
                    pro = pro.OrderByDescending(row => row.Price).ToList();
                    break;
                default:
                    break;
            }
            return View(pro);
        }
        public ActionResult Detail(int id)
        {
            ShopDBContext db = new ShopDBContext();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
        public ActionResult LocTheoChuDe(int id, string sort)
        {
            ShopDBContext db = new ShopDBContext();
            List<Product> pro = db.Products.Where(row =>
                row.CategoryID == id).ToList();
            switch (sort)
            {
                case "TangDan":
                    pro = pro.OrderBy(row => row.Price).ToList();
                    break;
                case "GiamDan":
                    pro = pro.OrderByDescending(row => row.Price).ToList();
                    break;
                default:
                    break;
            }
            ViewBag.id = id;
            return View(pro);
        }
    }
}