namespace PinionCyber.NetCode
{
    public abstract class StreamGetter : UnityEngine.MonoBehaviour
    {
        public abstract Regulus.Network.IStreamable GetStream();
    }

}
