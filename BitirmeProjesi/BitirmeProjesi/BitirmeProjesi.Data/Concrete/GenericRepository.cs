using BitirmeProjesi.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
      where TEntity : class
    {
        protected readonly ProjeDbContext _context;
        private DbSet<TEntity> _entity;
        public GenericRepository(ProjeDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();

        }
        
        public void Create(TEntity entity)
        {
            
            
                _entity.Add(entity);
                _context.SaveChanges();
            
        }

        public void Update(TEntity entity)
        {
            
                _entity.Update(entity);
                _context.SaveChanges();
            
        }

        public void Delete(TEntity entity)
        {
            
                _entity.Remove(entity);
                _context.SaveChanges();
            
        }

        public List<TEntity> GetAll()
        {
            
                return _entity.ToList();
            
        }

        public TEntity GetById(int id)
        {
            
                return _entity.Find(id);
            
        }
    }
}
