using System;

namespace Milenium.Application.Contracts.Providers
{
    public interface IDateTimeProvider
    {
        public DateTime DateTimeUtcNow { get; }
    }
}
