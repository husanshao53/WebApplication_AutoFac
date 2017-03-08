using AutoFac_Demo2.IRepository;
using AutoFac_Demo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Demo2.Repository
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> Products = new List<Product>();

        public ProductRepository()
        {
            Add(new Product { Id = 1, Name = "手机", Price = 100, Remark = "4g 手机", Date = DateTime.Now.AddDays(-1) });
            Add(new Product { Id = 2, Name = "电脑", Price = 120, Remark = "笔记本本", Date = DateTime.Now.AddDays(-2) });
            Add(new Product { Id = 3, Name = "bb机", Price = 10, Remark = "大时代必备", Date = DateTime.Now.AddDays(-1100) });
            Add(new Product { Id = 4, Name = "pad", Price = 130, Remark = "mini 电脑", Date = DateTime.Now });
        }
        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public Product Get(int id)
        {
            return Products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Products.Add(item);
            return item;
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Products.RemoveAt(index);
            Products.Add(item);
            return true;
        }

        public bool Delete(int id)
        {
            Products.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}
