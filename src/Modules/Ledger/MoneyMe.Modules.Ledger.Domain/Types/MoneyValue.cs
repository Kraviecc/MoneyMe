namespace MoneyMe.Modules.Ledger.Domain.Types;

public class MoneyValue
{
	public decimal? Value { get; }

	public string Currency { get; }

	public bool HasValue => Value.HasValue;

	public bool IsZeroValue => Value == 0;

	public MoneyValue(decimal? value, string currency)
	{
		Value = value;
		Currency = currency;
	}

	public MoneyValue(decimal? value)
	{
		Value = value;
		Currency = "PLN";
	}

	public static implicit operator decimal?(MoneyValue moneyValue) => moneyValue.Value;

	public static implicit operator MoneyValue(decimal? value) => new(value);

	public override string ToString() => $"{Value.GetValueOrDefault()} {Currency}";
}