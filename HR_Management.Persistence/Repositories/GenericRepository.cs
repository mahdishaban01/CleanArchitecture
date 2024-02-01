using HR_Management.Application.Contracts.Persistence;

namespace HR_Management.Persistence.Repositories
{
    public class GenericRepository<T>(LeaveManagementDbContext context) : IGenericRepository<T> where T : class
    {
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(long id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Exist(long id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Add(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
