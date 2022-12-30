using PinionCyber.NetCode.Samples.Echo.Protocols;
using Regulus.Remote.Client;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Echo
{
    public class EchoClient : MonoBehaviour
    {
        public UnityEngine.UI.InputField Port;
        public UnityEngine.UI.InputField Address;
        public UnityEngine.UI.Text Message;

        public EchoEcho EchoEcho;
        public TcpAgent TcpAgent;
        public EchoClient()
        {
            
            
        }

        public void Connect()
        {
            var address = System.Net.IPAddress.Parse(Address.text);            
            TcpAgent.Connect(new System.Net.IPEndPoint(address , int.Parse(Port.text)));
        }

        public void Disconnect()
        {
            EchoEcho.Hide();

            TcpAgent.Disconnect();
        }
        
        public void Ready(Regulus.Remote.INotifierQueryable notifier)
        {
            notifier.QueryNotifier<Echoable>().Supply += _ShowEcho;
        }

        private void _ShowEcho(Echoable echo)
        {
            EchoEcho.Show(echo);
        }

       

        private void Start()
        {
            
            EchoEcho.Hide();
        }
    }

}
