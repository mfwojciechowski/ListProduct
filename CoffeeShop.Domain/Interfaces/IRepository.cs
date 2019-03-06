using CoffeeShop.Domain.Entities;
using System.Linq;

namespace CoffeeShop.Domain.Interfaces
{

    public interface IRepository<T>
    {
        IQueryable<T> Values { get; }
        void Save(T instance);
    }
}