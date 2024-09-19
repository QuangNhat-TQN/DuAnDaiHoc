using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoAnLapTrinhWeb.Models;

namespace DoAnLapTrinhWeb.ApiControllers
{
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            ShopDBContext db = new ShopDBContext();
            List<Product> products = db.Products.ToList();
            return products;
        }
    }
}
