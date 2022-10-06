using UnityEngine;

namespace PinionCyber.NetCode
{
    public abstract class ProtocolGetter : MonoBehaviour
    {
        public abstract Regulus.Remote.IProtocol GetProtocol();

    }

}
