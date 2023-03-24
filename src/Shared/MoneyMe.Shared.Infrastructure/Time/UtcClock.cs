using MoneyMe.Shared.Abstractions;

namespace MoneyMe.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}