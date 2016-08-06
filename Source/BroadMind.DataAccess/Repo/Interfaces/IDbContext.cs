using System.Data.Entity;
using BroadMind.DataAccess.Repo.Concrete;

namespace BroadMind.DataAccess.Repo.Interfaces
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}