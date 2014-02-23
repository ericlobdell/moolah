using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using moolah.Domain.Interfaces;

namespace moolah.Domain.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IMobileServiceClient MobileServiceClient { get; set; }

        protected BaseRepository ( IMobileServiceClient mobileServiceClient )
        {
            if ( mobileServiceClient == null ) throw new ArgumentNullException( "mobileServiceClient" );
            this.MobileServiceClient = mobileServiceClient;
        }

        protected virtual IMobileServiceTable<TEntity> GetTable ()
        {
            return this.MobileServiceClient.GetTable<TEntity>();
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync ()
        {
            return GetTable().ToEnumerableAsync();
        }
        public virtual Task CreateAsync ( TEntity entity )
        {
            return GetTable().InsertAsync( entity );
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync ( Expression<Func<TEntity, bool>> predicate )
        {
            return GetTable().Where( predicate ).ToEnumerableAsync();
        }

        public virtual Task UpdateAsync ( TEntity entity )
        {
            return GetTable().UpdateAsync( entity );
        }
        public virtual Task RemoveAsync ( TEntity entity )
        {
            return GetTable().DeleteAsync( entity );
        }
    } 
}
