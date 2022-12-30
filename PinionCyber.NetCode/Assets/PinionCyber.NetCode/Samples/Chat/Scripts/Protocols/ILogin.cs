namespace PinionCyber.NetCode.Samples.Chat.Protocols
{
    public interface ILogin
    {
        Regulus.Remote.Value<bool> Login(string name);
    }

}

