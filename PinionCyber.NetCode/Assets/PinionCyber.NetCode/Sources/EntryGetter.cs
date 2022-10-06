using UnityEngine;

namespace PinionCyber.NetCode
{
    public abstract class EntryGetter : MonoBehaviour 
    {
        public abstract Regulus.Remote.IEntry GetEntry();
        
    }

}
