using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyAuthServer.Core.Repositories;

namespace UdemyAuthServer.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task AddAysync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            //
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;


            }
            return entity;
        }

        public void Remove(TEntity entity)
        {
           _dbSet.Remove(entity);
            //yada deleted verebilirz entitystate
        }

        public TEntity Update(TEntity entity)
        {
            // reository kulnmasaydık 
            //product.getbydı(1)
            //product.name="kalem"
            //context.savecahnge   
            //repository kullnırsak tek bir field değişse bile hepsi hepsini update eder
            _context.Entry(entity).State |= EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
           return _dbSet.Where(predicate);
        }
    }
}
