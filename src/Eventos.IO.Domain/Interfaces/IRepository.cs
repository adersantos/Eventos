using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);

        TEntity GetById(Guid Id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(Guid Id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}
