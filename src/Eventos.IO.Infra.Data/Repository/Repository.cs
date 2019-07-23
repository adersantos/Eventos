using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Eventos.Interfaces;
using Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected EventosContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(EventosContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }
        
        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
        
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}