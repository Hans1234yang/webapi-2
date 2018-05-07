using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi_尝试2.Models
{
    //商品仓储类 
    public class ProductRepository: IProductRepository
    {
        //创建 产品类型的 列表
        private List<Product> products = new List<Product>();
        private int _nextId = 1;


        public ProductRepository()
        {
            Add(new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
            Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
            Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
        }

        /// <summary>
        /// 产品类型的列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        /// <summary>
        /// 根据id获取 产品 get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id)
        {
            return products.Find(p => p.Id ==id);
        }

        public Product Add(Product item)
        {
            //if(item==null)
            //{
            //    throw new ArgumentNullException("item");
            //}

           
            item.Id = _nextId;    ///赋予id
           _nextId = _nextId + 1;
            products.Add(item);   ///主要给 item 加上 
 
            return item;    ///返回这个要添加的对象            
        }

        /// <summary>
        /// 根据id删除 产品
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            products.RemoveAll(p =>p.Id == id);
        }

        /// <summary>
        /// 传入整个model，然后进行修改
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public  bool Update(Product item)
        {
            //if (item == null)
            //{
            //    throw new ArgumentNullException("item");
            //}

            int index = products.FindIndex(p=>p.Id==item.Id);

            if(index==-1)   
            {
                return false;
            }

            products.RemoveAt(index);
            products.Add(item);
           return  true;
        }
    }
}