using System.Collections.Generic;
using System.Threading.Tasks;
using moolah.Domain.Models;
using moolah.Domain.Services;

namespace moolah.Domain.Interfaces
{
    public interface IApiService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<int> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);

        void SetApiManager(IApiRequestManager<ApiResponse> mgr);
        void SetBaseUrl(string url);

    }
}
