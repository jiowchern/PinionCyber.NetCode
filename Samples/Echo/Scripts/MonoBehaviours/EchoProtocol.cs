using Regulus.Remote;

namespace PinionCyber.NetCode.Samples.Echo
{
    public class EchoProtocol : PinionCyber.NetCode.ProtocolGetter
    {
        private readonly IProtocol _Protocol;

        public EchoProtocol()
        {
            _Protocol = Protocols.ProtocolCreator.Create();
        }
        public override Regulus.Remote.IProtocol GetProtocol()
        {
            return _Protocol;
        }
    }

}
