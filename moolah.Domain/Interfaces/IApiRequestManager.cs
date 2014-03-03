using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moolah.Domain.Interfaces
{
    public interface IApiRequestManager<T>
    {
        Task<T> Get(string url);
        Task<bool> Put ( string url, object obj );
        Task<T> Post ( string url, object obj );
        Task<bool> Delete(string url);
    }
}
