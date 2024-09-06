using Microsoft.EntityFrameworkCore;
using Parcial_1.DataAccess.Interfaces;
using Parcial_1.Models;
using System.Linq.Expressions;

namespace Parcial_1.DataAccess.Servicios
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly IRepository<T> _repository;
        private readonly ApplicationDbContext _context;
        

        public Repository(ApplicationDbContext context)
        {
            this._context = context;            
        }
        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await EntitySet.FindAsync(id);            
                
        }

        //Agregar un registro
        public async Task<T> AgregarAsync(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }
        //eliminar registro
        public async Task<T> EliminarAsync(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await Save();
            return entity;
        }

        //actualizar registro
        public async Task ActualizarAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public int AuxContar(Expression<Func<T, bool>> expression)
        {
            using(var db = new ApplicationDbContext())
            {
                return db.Set<T>().Where(expression).Count();
            }
        }

        public async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr);
        }


    }
}
