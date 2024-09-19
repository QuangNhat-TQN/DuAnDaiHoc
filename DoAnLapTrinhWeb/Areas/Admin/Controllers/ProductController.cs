using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLapTrinhWeb.Models;
using DoAnLapTrinhWeb.Filters;

namespace DoAnLapTrinhWeb.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string sort, int page = 1, string search = "")
        {
            ShopDBContext db = new ShopDBContext();
            List<Product> pro = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
            switch (sort)
            {
                case "IdTangDan":
                    pro = pro.OrderBy(row => row.ProductID).ToList();
                    break;
                case "IdGiamDan":
                    pro = pro.OrderByDescending(row => row.ProductID).ToList();
                    break;
                case "TenTangDan":
                    pro = pro.OrderBy(row => row.ProductName).ToList();
                    break;
                case "TenGiamDan":
                    pro = pro.OrderByDescending(row => row.ProductName).ToList();
                    break;
                case "GiaTangDan":
                    pro = pro.OrderBy(row => row.Price).ToList();
                    break;
                case "GiaGiamDan":
                    pro = pro.OrderByDescending(row => row.Price).ToList();
                    break;
                case "MatDinh":
                    pro = pro = db.Products.Where(row => row.ProductName.Contains(search)).ToList();
                    break;
                default:
                    break;
            }
            ViewBag.sort = sort;
            int SoPhanTuTrong1Trang = 5;
            int SoMuonLamTrangDeChia = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(pro.Count) / Convert.ToDouble(SoPhanTuTrong1Trang)));
            int noOfRecordToSkip = (page - 1) * SoPhanTuTrong1Trang;
            ViewBag.page = page;
            ViewBag.NoOfPage = SoMuonLamTrangDeChia;
            pro = pro.Skip(noOfRecordToSkip).Take(SoPhanTuTrong1Trang).ToList();
            return View(pro);

        }
        public ActionResult Detail(int id)
        {
            ShopDBContext db = new ShopDBContext();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
        public ActionResult Create()
        {
            ShopDBContext db = new ShopDBContext();
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Product pro)
        {
            ShopDBContext db = new ShopDBContext();
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            ShopDBContext db = new ShopDBContext();
            ViewBag.Category = db.Categories.ToList();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            ShopDBContext db = new ShopDBContext();
            Product product = db.Products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();
            product.ProductName = pro.ProductName;
            product.Price = pro.Price;
            product.Img = pro.Img;
            product.CategoryID = pro.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ShopDBContext db = new ShopDBContext();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product e)
        {

            ShopDBContext db = new ShopDBContext();
            Product pro = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct()
        {
            return View();
        }
    }
}