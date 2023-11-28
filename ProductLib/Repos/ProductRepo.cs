using Microsoft.EntityFrameworkCore;
using ProductLib.Extensions;
using System;

namespace ProductLib;
public class ProductRepo
    :IProductRepo
{
    private readonly IDbContext _context = default!;
    public ProductRepo(IDbContext context)
    {
        _context = context;
    }
    public void Create(Product entity)
    {
        try
        {
            _context.Products.Add(entity.Clone());
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create > {ex.Message}");
        }
    }
    public IQueryable<Product> GetQueryable()
    {
        return _context.Products.AsQueryable();
    }

    public bool Update(Product entity)
    {
        try
        {
            _context.Products.Update(entity);
            return _context.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to update > {ex.Message}");
        }
    }
    public bool Delete(Product entity)
    {
        try
        {
            _context.Products.Remove(entity);
            return _context.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to delete > {ex.Message}");
        }
    }
    public IDbContext DbContext => _context;
}