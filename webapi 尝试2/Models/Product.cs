using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_尝试2.Models
{
    //商品实体类
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

}