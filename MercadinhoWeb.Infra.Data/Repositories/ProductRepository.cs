using MercadinhoWeb.Domain.Entities;
using MercadinhoWeb.Domain.Interfaces.Repositories;
using MercadinhoWeb.Infra.Data.Context;
using MercadinhoWeb.Infra.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Infra.Data.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Product> FindByIdAsync(Guid id)
    {
        var product = await _appDbContext.Products.Include(x => x.Category).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if(product is null)
        {
            throw new ResourceNotFoundException();
        }
        return product;
    }

    public async Task SaveAsync(Product product)
    {
        try
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }
        catch(DbUpdateException ex) 
        {
            throw new ResourceInsertException("Erro inserting product", ex);
        }
    }

    public async Task UpdateAsync(Product product)
    {
        try
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
        catch(DbUpdateException ex)
        {
            throw new ResourceUpdateException("Erro updating product", ex);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _appDbContext.Products.FindAsync(id);
        if (product is null)
        {
            throw new ResourceNotFoundException();
        }

        try
        {
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }
        catch(DbUpdateException ex)
        {
            throw new ResourceDeleteException("Erro deleting product", ex);
        }
    }

    public async Task<IEnumerable<Product>> FindAllAsync(int skip = 0, int take = 30, string termSearch = "", string categoryId = "")
    {
        return await _appDbContext.Products.Skip(skip).Take(take).Where(x => x.Name.Contains(termSearch)).Where(x => x.CategoryId.ToString().Contains(categoryId)).Include(x => x.Category).AsNoTracking().ToListAsync();
    }
}
