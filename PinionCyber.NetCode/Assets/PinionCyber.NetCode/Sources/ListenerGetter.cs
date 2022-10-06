using UnityEngine;

namespace PinionCyber.NetCode
{
    public abstract class ListenerGetter : MonoBehaviour
    {
        public abstract Regulus.Remote.Soul.IListenable GetListener();
    }

}
