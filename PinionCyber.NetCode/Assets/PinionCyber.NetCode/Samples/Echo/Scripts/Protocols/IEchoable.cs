namespace PinionCyber.NetCode.Samples.Echo.Protocols
{
    public interface IEchoable : Regulus.Remote.Protocolable
    {
        Regulus.Remote.Value<string> Echo(string message);
    }
}
