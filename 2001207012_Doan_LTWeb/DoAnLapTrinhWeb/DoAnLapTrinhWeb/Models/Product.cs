using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnLapTrinhWeb.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<float> Price { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public Nullable<int> Trend { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}