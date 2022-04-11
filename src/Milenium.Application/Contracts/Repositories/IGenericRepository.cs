using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Milenium.Application.Contracts.Repositories
{
    public interface IGenericRepository<TModel>
    {
        Task CreateAsync(TModel parts, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> FindAsync(Expression<Func<TModel, bool>> expression, CancellationToken cancellationToken = default);
        Task UpdateAsync(TModel model, CancellationToken cancellationToken = default);
        Task DeleteAsync(TModel model, CancellationToken cancellationToken = default);
    }
}
