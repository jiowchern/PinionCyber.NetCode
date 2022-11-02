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
        public TcpConnecter TcpConnecter;
        public Agent Agent;
        public EchoClient()
        {
            
            
        }
        public void Connect()
        {
            TcpConnecter.Connect(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(Address.text), int.Parse(Port.text)));            
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
