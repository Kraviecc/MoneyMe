namespace MoneyMe.Shared.Infrastructure.Modules;

public interface IModuleRegistry
{
	IEnumerable<ModuleBroadcastRegistration> GetModuleBroadcastRegistrations(string key);

	void AddBroadcastAction(Type requestType, Func<object, Task?> action);
}