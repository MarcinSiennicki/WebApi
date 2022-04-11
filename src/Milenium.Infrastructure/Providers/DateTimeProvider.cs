using Milenium.Application.Contracts.Providers;
using System;

namespace Milenium.Infrastructure.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeUtcNow => DateTime.UtcNow;
    }
}
