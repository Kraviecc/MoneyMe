namespace MoneyMe.Shared.Infrastructure.Modules;

public interface IModuleSerializer
{
	byte[] Serialize<T>(T value);

	object? Deserialize(byte[] value, Type type);

	T? Deserialize<T>(byte[] value);
}