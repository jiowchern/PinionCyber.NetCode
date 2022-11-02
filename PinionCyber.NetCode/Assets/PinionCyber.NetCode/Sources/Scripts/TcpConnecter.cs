using Regulus.Network;
using Regulus.Network.Tcp;
using System.Net.Sockets;

namespace PinionCyber.NetCode
{
    public class TcpConnecter : StreamGetter
    {
        private readonly Connecter _Connecter;

        public UnityEngine.Events.UnityEvent SuccessEvent;
        public UnityEngine.Events.UnityEvent FailedEvent;
        public UnityEngine.Events.UnityEvent<SocketError> SockerErrorEvent;

        public TcpConnecter()
        {
            
            _Connecter = new Regulus.Network.Tcp.Connecter();
            _Connecter.SocketErrorEvent += _SocketError;
        }

        private void _SocketError(SocketError code)
        {
            MainThreadQueue.Post(() => SockerErrorEvent.Invoke(code));
        }

        public override IStreamable GetStream()
        {
            return _Connecter;
        }

        public async void Connect(System.Net.IPEndPoint ep)
        {
            var result = await _Connecter.Connect(ep);
            if(result)
                MainThreadQueue.Post(() => { SuccessEvent.Invoke(); });
            else
                MainThreadQueue.Post(() => { FailedEvent.Invoke(); });
        }

    
    }

}
