using MoneyMe.Modules.Ledger.Domain.Categories.Consts;

namespace MoneyMe.Modules.Ledger.Domain.Types;

public class CategoryType : IEquatable<CategoryType>
{
	public string Value { get; }

	public bool IsValid => CategoryTypes.IsValid(Value);

	public CategoryType(string value)
	{
		Value = value;
	}

	public static implicit operator string(CategoryType categoryType) => categoryType.Value;

	public static implicit operator CategoryType(string value) => new(value);

	public override string ToString() => Value;

	public bool Equals(CategoryType? other)
	{
		if (ReferenceEquals(null, other))
		{
			return false;
		}

		if (ReferenceEquals(this, other))
		{
			return true;
		}

		return Value == other.Value;
	}

	public override bool Equals(object? obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}

		if (ReferenceEquals(this, obj))
		{
			return true;
		}

		if (obj.GetType() != GetType())
		{
			return false;
		}

		return Equals((CategoryType)obj);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}
}