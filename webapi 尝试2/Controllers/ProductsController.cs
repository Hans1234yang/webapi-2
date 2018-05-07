using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using webapi_尝试2.Models;
namespace webapi_尝试2.Controllers
{
    public class ProductsController : ApiController
    {
        //创建子对象， 创建父变量，李式替代 法则

        static readonly IProductRepository repository1= new ProductRepository(); 

        //获取产品列表
     
        public IEnumerable <Product> GetAllProducts()
        {
            //调用仓储类的方法
            return repository1.GetAll();   
        }

        //根据id获取具体产品 ,调用仓储类的 方法
       
        public Product GetProduct(int id)
        {
            Product item = repository1.Get(id);
            if(item==null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            return item;
        }

        //新增 产品 
        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository1.Add(item);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent("add success", System.Text.Encoding.UTF8, "text/plain")
            };
        }


        //根据id 删除对应的产品
        public void DeleteProduct(int id)
        {
            repository1.Remove(id);
        }
    }
}