using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moolah.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get ();
        T GetById ( int id );
        T Create ( T obj );
        void Update ( T obj );
        void Delete ( int id );
    }
}
