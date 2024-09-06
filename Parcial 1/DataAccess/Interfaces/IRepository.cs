using Parcial_1.Models;
using System.Linq.Expressions;

namespace Parcial_1.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {//Interfaces generica para ser utilizada con cualquier repositorio

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> AgregarAsync(T entity);
        Task<T> EliminarAsync(int id);
        Task ActualizarAsync(T entity);
        int AuxContar(Expression<Func<T, bool>> expression);
        Task<T> Find(Expression<Func<T, bool>> expr);



    }
}
