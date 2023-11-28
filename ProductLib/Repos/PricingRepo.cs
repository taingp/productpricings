namespace ProductLib;

public class PricingRepo : IPricingRepo
{
    private readonly IDbContext _context = default!;
    public PricingRepo(IDbContext context)
    {
        _context = context;
    }
    public IDbContext DbContext => _context;

    public void Create(Pricing entity)
    {
        try
        {
            _context.Pricings.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create > {ex.Message}");
        }
    }
    public IQueryable<Pricing> GetQueryable()
    {
        return _context.Pricings.AsQueryable();
    }

    public bool Update(Pricing entity)
    {
        try
        {
            _context.Pricings.Update(entity);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to update > {ex.Message}");
        }
    }
    public bool Delete(Pricing entity)
    {
        try
        {
            _context.Pricings.Remove(entity);
            return _context.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to delete > {ex.Message}");
        }
    }
}