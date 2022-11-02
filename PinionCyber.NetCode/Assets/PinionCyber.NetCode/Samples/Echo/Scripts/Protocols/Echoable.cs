namespace PinionCyber.NetCode.Samples.Echo.Protocols
{
    public interface Echoable  : Regulus.Remote.Protocolable
    {   
        Regulus.Remote.Value<string> Echo(string message);
         
        
    }
}
