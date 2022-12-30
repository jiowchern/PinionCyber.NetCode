using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Chat.Protocols
{
    public static partial class ProtocolCreator
    {
        public static Regulus.Remote.IProtocol Create()
        {
            Regulus.Remote.IProtocol protocol = null;
            _Create(ref protocol);
            return protocol;
        }

        [Regulus.Remote.Protocol.Creater]
        static partial void _Create(ref Regulus.Remote.IProtocol protocol);

    }

}

