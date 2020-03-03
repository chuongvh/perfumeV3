using System;
using System.Collections.Generic;
using System.Linq;
using S3Train.Contract;
using S3Train.Domain;

namespace S3Train.Service
{
    public class ProductService : GenenicServiceBase<Product>, IProductService
    {
        public ProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Product> GetProductsByBrandId(Guid brand_Id)
        {
            return this.EntityDbSet.Where(x => x.Brand_Id == brand_Id && x.IsActive == true).ToList();
        }
        public IList<Product> GetProductsByVendorId(Guid vendor_Id)
        {
            return this.EntityDbSet.Where(x => x.Vendor_Id == vendor_Id && x.IsActive == true).ToList();
        }

        public List<Product> GetProductsByCategoryId(Guid category_Id)
        {
            var query = from product in this.EntityDbSet
                        where product.Categories.Any(c => c.Id == category_Id)
                        select product;
            return query.ToList();
        }

        /// <summary>
        /// Insert Product in category
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="product">Product</param>
        public void InsertProductOnCategory(Guid category_Id, Guid product_Id)
        {
            var category = DbContext.Categories.FirstOrDefault(c => c.Id == category_Id);
            var product = this.EntityDbSet.FirstOrDefault(p => p.Id == product_Id);
            var checkPro = category.Products.FirstOrDefault(p=>p.Id == product.Id);

            if(category != null && product != null)
            {
                if (checkPro != null)
                {
                    category.Products.Remove(checkPro);
                    category.Products.Add(product);
                }
                else
                {
                    category.Products.Add(product);
                }
            }
            
            
            this.DbContext.SaveChanges();
        }

        public void DeleteProductOnCategory(Guid category_Id, Guid product_Id)
        {
            var category = DbContext.Categories.FirstOrDefault(c => c.Id == category_Id);
            var product = this.EntityDbSet.FirstOrDefault(p => p.Id == product_Id);
            var checkPro = category.Products.FirstOrDefault(p => p.Id == product.Id);

            if (category != null && product != null)
            {
                if (checkPro != null)
                {
                    category.Products.Remove(checkPro);
                }
            }
            this.DbContext.SaveChanges();
        }
    }
}