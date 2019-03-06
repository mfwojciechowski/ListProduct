using System.Linq;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;

namespace CoffeeShop.Domain.DbConc
{
    public class EfProductRepository : IProductRepository
    {
        private EfDbContext context = new EfDbContext();

        public IQueryable<Product> Values
        {
            get { return context.Products; }
        }

        public void Save(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                    dbEntry.Quantity = product.Quantity;
                }
            }
            context.SaveChanges();
        }

        /* public Product Delete(int product)
         {
             Product dbEntry = context.Products.Find(product);
             if (dbEntry != null)
             {
                 context.Products.Remove(dbEntry);
                 context.SaveChanges();
             }

             return dbEntry;
         }
         */
    }
}
