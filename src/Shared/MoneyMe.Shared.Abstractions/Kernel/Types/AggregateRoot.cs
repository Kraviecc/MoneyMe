namespace MoneyMe.Shared.Abstractions.Kernel.Types;

public abstract class AggregateRoot<T>
{
	public T Id { get; protected set; }

	public int Version { get; protected set; }

	public IEnumerable<IDomainEvent> Events => _events;

	private readonly List<IDomainEvent> _events = new();
	private bool _versionIncremented;

	protected void AddEvent(IDomainEvent @event)
	{
		if (!_events.Any() && !_versionIncremented)
		{
			Version++;
			_versionIncremented = true;
		}

		_events.Add(@event);
	}

	public void ClearEvents() => _events.Clear();
	public void ResetVersion() => Version = 0;

	public void ReinitAggregate()
	{
		ClearEvents();
		ResetVersion();
	}

	protected void IncrementVersion()
	{
		if (_versionIncremented)
		{
			return;
		}

		Version++;
		_versionIncremented = true;
	}
}

public abstract class AggregateRoot : AggregateRoot<AggregateId> { }