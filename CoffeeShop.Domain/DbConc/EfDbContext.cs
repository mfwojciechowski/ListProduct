using System.Data.Entity;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Domain.DbConc
{
    public class EfDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}