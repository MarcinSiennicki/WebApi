using AutoMapper;
using Microsoft.Extensions.Options;
using Milenium.Application.Configuration;
using Milenium.Application.Contracts.Providers;
using Milenium.Domain;
using Milenium.Infrastructure.Persistance.Documents;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Milenium.Infrastructure.Persistance.Repositories
{
    public class UserRepository : GenericRepository<UserModel, UserDocument>
    {
        private readonly IMapper _mapper;
        private readonly IDateTimeProvider _dateTimeProvider;
        public UserRepository(
            IMapper mapper,
            IDateTimeProvider dateTimeProvider,
            IMongoDatabase context,
            IOptions<MongoConfig> mongoOptions)
            : base(context, mongoOptions.Value.UserCollectionName)
        {
            _mapper = mapper;
            _dateTimeProvider = dateTimeProvider;
        }
        public override async Task CreateAsync(UserModel user, CancellationToken cancellationToken = default)
        {
            if (user is null)
            {
                return;
            }

            var document = _mapper.Map<UserDocument>(user);
            document.CreatedOn = _dateTimeProvider.DateTimeUtcNow;

            await Collection.InsertOneAsync(document, null, cancellationToken);
        }

        public override Task DeleteAsync(UserModel model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<UserModel>> FindAsync(Expression<Func<UserModel, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(UserModel model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
