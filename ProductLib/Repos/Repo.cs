namespace ProductLib;

public class Repo<TEntity>
    : IRepo<TEntity>
    where TEntity : class, IKey
{
    protected readonly IDbContext _context = default!;

    public Repo(IDbContext context)
    {
        _context = context;
    }
 
    public IDbContext DbContext => _context;
    public virtual void Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
    public virtual int CreateRange(IEnumerable<TEntity> entities)
    {
        try
        {
            _context.Set<TEntity>().AddRange(entities);
            return _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }

    public virtual IQueryable<TEntity> GetQueryable()
    {
        return _context.Set<TEntity>().AsQueryable();
    }

    public virtual bool Update(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
    public bool Delete(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges()>0;
        }
        catch (Exception ex)
        {
            throw new Exception($"{ex.Message}");
        }
    }
}