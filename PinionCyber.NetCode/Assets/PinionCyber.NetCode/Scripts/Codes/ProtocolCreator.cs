namespace PinionCyber.NetCode
{
    namespace Codes
    {

        public static partial class ProtocolCreator
        {
            public static Regulus.Remote.IProtocol Create()
            {
                Regulus.Remote.IProtocol protocol = null;
                _Create(ref protocol);
                return protocol;
            }

            /*
                Create a partial method as follows.
            */
            [Regulus.Remote.Protocol.Creater]
            static partial void _Create(ref Regulus.Remote.IProtocol protocol);
        }
    }

    

}
