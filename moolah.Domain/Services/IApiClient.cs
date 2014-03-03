using System.Collections.Generic;
using System.Threading.Tasks;

namespace moolah.Domain.Services
{
    public interface IApiClient<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
