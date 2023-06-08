namespace MoneyMe.Shared.Abstractions.Kernel.Types;

public class ValueChanged<T>
{
	public T Value { get; set; }

	public bool IsChanged { get; set; }
}