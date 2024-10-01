
using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}