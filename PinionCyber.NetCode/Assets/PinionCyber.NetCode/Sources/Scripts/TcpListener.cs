using System;

namespace PinionCyber.NetCode
{
    public class TcpListener : ListenerGetter
    {
        

        public UnityEngine.Events.UnityEvent SuccessEvent;

        
        readonly Regulus.Remote.Server.Tcp.Listener _Listener;
        public TcpListener()
        {
            _Listener = new Regulus.Remote.Server.Tcp.Listener();
        }
        public override Regulus.Remote.Soul.IListenable GetListener()
        {
            return _Listener;
        }
        public void Bind(int port)
        {
            _Listener.Bind(port);
            SuccessEvent.Invoke();
        }

        public void Close()
        {
            _Listener.Close();
        }
        
    }

}
