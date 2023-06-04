using MoneyMe.Shared.Abstractions;
using MoneyMe.Shared.Abstractions.Time;

namespace MoneyMe.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate() => DateTime.UtcNow;
}