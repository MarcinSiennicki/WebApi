using Milenium.Application.Contracts.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Milenium.Infrastructure.Persistance
{
    public abstract class GenericRepository<TModel, TEntity> : IGenericRepository<TModel>
    {
        protected GenericRepository(
            IMongoDatabase context,
            string collectionName)
        {
            Collection = context.GetCollection<TEntity>(collectionName);
        }

        protected IMongoCollection<TEntity> Collection { get; }

        public abstract Task CreateAsync(TModel model, CancellationToken cancellationToken = default);
        public abstract Task DeleteAsync(TModel model, CancellationToken cancellationToken = default);
        public abstract Task UpdateAsync(TModel model, CancellationToken cancellationToken = default);

        public abstract Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> expression,
            CancellationToken cancellationToken = default);


    }
}
