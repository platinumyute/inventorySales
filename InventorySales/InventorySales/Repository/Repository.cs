using InventorySales.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySales.Models;

namespace InventorySales.Repository
{
     public class Repository<TEntity> where TEntity : class
     {
          internal DbContext _context;
          internal DbSet<TEntity> _dbSet;

          public Repository()
          {
               string connectionstring = Database.ConnectionStrings.InventorySalesConnection;
               init(new InventorySalesDb(connectionstring));
          }
          public Repository(DbContext context)
          {
               init(context);
          }
          private void init(DbContext context)
          {
               _context = context;
               _dbSet = _context.Set<TEntity>();
          }

          public IQueryable<TEntity> All()
          {
               return _dbSet.AsNoTracking();
          }

          public IEnumerable<TEntity> All(Func<TEntity, bool> filter)
          {
               return _dbSet.AsNoTracking().Where(filter);
          }

          public bool Any(Func<TEntity, bool> filter)
          {
               return _dbSet.AsNoTracking().Any(filter);
          }

          public TEntity GetById(int id)
          {
               return _dbSet.Find(id);
          }

          /// <summary>
          /// adds entity to collection
          /// </summary>
          /// <param name="entity"></param>
          public void Add(TEntity entity)
          {
               _dbSet.Add(entity);
               _context.SaveChanges();
          }
          /// <summary>
          /// updates an existing record
          /// </summary>
          /// <param name="entity"></param>
          public void Update(TEntity entity)
          {
               _context.Entry(entity).State = EntityState.Modified;
               _context.SaveChanges();
          }

          /// <summary>
          /// removes entity from collection
          /// </summary>
          /// <param name="entity"></param>
          public void Remove(TEntity entity)
          {
               _context.Entry(entity).State = EntityState.Deleted;
               _context.SaveChanges();
          }

     }
}
