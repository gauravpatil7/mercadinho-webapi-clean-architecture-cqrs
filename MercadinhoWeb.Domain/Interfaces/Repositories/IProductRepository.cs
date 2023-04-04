using MercadinhoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> FindAllAsync(int skip = 0, int take = 30, string termSearch = "", string categoryId = "");
    Task<Product> FindByIdAsync(Guid id);
    Task SaveAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);


}
