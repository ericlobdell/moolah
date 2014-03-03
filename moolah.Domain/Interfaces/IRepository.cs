using System.Collections.Generic;
using System.Threading.Tasks;

namespace moolah.Domain.Interfaces
{
    public interface IRepository<T>
    {
        //IEnumerable<T> Get ();
        //T GetById ( int id );
        //T Create ( T obj );
        //void Update ( T obj );
        //void Delete ( int id );

        Task<IEnumerable<T>> GetAllAsync ();
        Task CreateAsync ( T entity );
        Task UpdateAsync ( T entity );
        Task RemoveAsync ( T entity );
    }
}
