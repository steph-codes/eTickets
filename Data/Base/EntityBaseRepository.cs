using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        //one line function
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(int Id) =>  await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task UpdateAsync(int Id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

            //return entityEntry; //if you want to return the updated object yu add <T> in task and then return the object 
        }
        public async Task DeleteAsync(int Id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == Id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }




        // remove {} and write them in a single line 

        //public async Task AddAsync(T entity)
        //{
        //    _context.Set<T>().AddAsync(entity);
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    var result = await _context.Set<T>().ToListAsync();
        //    return result;
        //}


        //public async Task<T> GetByIdAsync(int Id)
        //{
        //    var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        //    return result;
        //}

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    var result = await _context.Set<T>().ToListAsync();
        //    return result;
        //}
    }
}
