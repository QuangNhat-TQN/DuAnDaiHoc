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
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string sort, int page = 1, string search = "")
        {
            ShopDBContext db = new ShopDBContext();
            List<Category> cate = db.Categories.Where(row => row.CategoryName.Contains(search)).ToList();
            switch (sort)
            {
                case "IdTangDan":
                    cate = cate.OrderBy(row => row.CategoryID).ToList();
                    break;
                case "IdGiamDan":
                    cate = cate.OrderByDescending(row => row.CategoryID).ToList();
                    break;
                case "TenTangDan":
                    cate = cate.OrderBy(row => row.CategoryName).ToList();
                    break;
                case "TenGiamDan":
                    cate = cate.OrderByDescending(row => row.CategoryName).ToList();
                    break;
                case "MatDinh":
                    cate = cate = db.Categories.Where(row => row.CategoryName.Contains(search)).ToList();
                    break;
                default:
                    break;
            }
            ViewBag.sort = sort;
            int SoPhanTuTrong1Trang = 5;
            int SoMuonLamTrangDeChia = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cate.Count) / Convert.ToDouble(SoPhanTuTrong1Trang)));
            int noOfRecordToSkip = (page - 1) * SoPhanTuTrong1Trang;
            ViewBag.page = page;
            ViewBag.NoOfPage = SoMuonLamTrangDeChia;
            cate = cate.Skip(noOfRecordToSkip).Take(SoPhanTuTrong1Trang).ToList();
            return View(cate);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Category cate)
        {
            ShopDBContext db = new ShopDBContext();
            db.Categories.Add(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ShopDBContext db = new ShopDBContext();
            Category cate = db.Categories.Where(row => row.CategoryID == id).FirstOrDefault();
            return View(cate);
        }
        [HttpPost]
        public ActionResult Edit(Category cate)
        {
            ShopDBContext db = new ShopDBContext();
            Category Category = db.Categories.Where(row => row.CategoryID == cate.CategoryID).FirstOrDefault();
            Category.CategoryName = cate.CategoryName;
            Category.CategoryID = cate.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            ShopDBContext db = new ShopDBContext();
            Category cate = db.Categories.Where(row => row.CategoryID == id).FirstOrDefault();
            return View(cate);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category e)
        {

            ShopDBContext db = new ShopDBContext();
            Category cate = db.Categories.Where(row => row.CategoryID == id).FirstOrDefault();
            db.Categories.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}