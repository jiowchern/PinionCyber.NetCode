namespace PinionCyber.NetCode.Samples.Chat.Protocols
{
    public interface IChatter : Regulus.Remote.Protocolable
    {
        Regulus.Remote.Property<string> Name { get; }
        void Whisper(string message);
    }

}

