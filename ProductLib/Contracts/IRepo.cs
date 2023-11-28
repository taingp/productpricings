﻿namespace ProductLib
{
    public interface IRepo<TEntity>
        where TEntity : IKey
    {
        IDbContext DbContext { get; }

        void Create(TEntity entity);
        IQueryable<TEntity> GetQueryable();
        public bool Update(TEntity entity);
        public bool Delete(TEntity entity);
    }
}
