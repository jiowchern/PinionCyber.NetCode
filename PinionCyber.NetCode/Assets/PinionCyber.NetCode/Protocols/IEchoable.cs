namespace PinionCyber.NetCode
{
    public interface IEchoable : Regulus.Remote.Protocolable
    {
        Regulus.Remote.Value<string> Echo(string message);
    }
}
