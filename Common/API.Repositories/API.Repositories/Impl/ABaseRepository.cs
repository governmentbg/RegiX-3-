using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechnoLogica.API.Repositories.Contracts;

namespace TechnoLogica.API.Repositories.Impl
{
    /// <summary>
    /// Defines the <see cref="ABaseRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ABaseRepository<T, P, Db> : IBaseRepository<T, P, Db>
        where T : class
        where P : struct
        where Db : DbContext
    {
        /// <summary>
        /// Defines the DbContext
        /// </summary>
        /// 
        private Db _dbContext;

        public Db GetDbContext()
        {
            return this._dbContext;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ABaseRepository{T}"/> class.
        /// </summary>
        /// <param name="aDbContext"></param>
        protected ABaseRepository(Db aDbContext)
        {
            this._dbContext = aDbContext;
        }

        /// <summary>
        /// The SelectAll
        /// </summary>
        /// <returns>The <see cref="IQueryable{T}"/></returns>
        public virtual IQueryable<T> SelectAll()
        {
            return this._dbContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// The Select
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal"/></param>
        /// <returns>The <see cref="T"/></returns>
        public virtual T Select(P aId)
        {
            var result = this._dbContext.Set<T>().Find(aId);
            if (result == null)
            {
                return null;
            }

            this._dbContext.Entry(result).Reload();
            return result;
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="aEntity">The aEntity<see cref="T"/></param>
        /// <returns>The <see cref="T"/></returns>
        public virtual T Insert(T aEntity)
        {
            var entityObj = _dbContext.Set<T>().Add(aEntity);
            return entityObj.Entity;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="aEntity">The aEntity<see cref="T"/></param>
        /// <returns>The <see cref="T"/></returns>
        public virtual T Update(T aEntity)
        {
            this._dbContext.Entry(aEntity).State = EntityState.Modified;
            return aEntity;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="aId">The aId<see cref="decimal"/></param>
        /// <returns>The <see cref="T"/></returns>
        public virtual T Delete(P aId)
        {
            T repoObj = this.Select(aId);
            this._dbContext.Set<T>().Remove(repoObj);
            return repoObj;
        }

    }
}
