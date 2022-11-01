namespace PinionCyber.NetCode
{
    public class TcpListener : ListenerGetter
    {
        public UnityEngine.UI.Text Port;

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
        public void Bind()
        {
            _Listener.Bind(int.Parse(Port.text));
            SuccessEvent.Invoke();
        }

        public void Close()
        {
            _Listener.Close();
        }
        
    }

}
