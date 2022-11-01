namespace PinionCyber.NetCode.Samples.Echo.Protocols
{
    public interface IEchoable  : ITabable
    {   
        Regulus.Remote.Value<string> Echo(string message);
         
        int Get();
    }
}
