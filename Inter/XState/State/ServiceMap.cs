namespace XState.State
{
    public interface IServiceMap : IDictionary<string, ServiceData> { }

    public class ServiceMap : Dictionary<string, ServiceData>, IServiceMap { }
}
