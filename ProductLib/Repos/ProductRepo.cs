using Microsoft.EntityFrameworkCore;
using ProductLib.Extensions;
using System;

namespace ProductLib;
public class ProductRepo
    : Repo<Product>
    , IProductRepo
{
    public ProductRepo(IDbContext context) : base(context) { }
}
