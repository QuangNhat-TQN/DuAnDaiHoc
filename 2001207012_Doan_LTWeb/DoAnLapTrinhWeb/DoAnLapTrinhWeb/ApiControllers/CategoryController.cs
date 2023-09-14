using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoAnLapTrinhWeb.Models;

namespace DoAnLapTrinhWeb.ApiControllers
{
    public class CategoryController : ApiController
    {
        public List<Category> Get()
        {
            ShopDBContext db = new ShopDBContext();
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
    }
}
