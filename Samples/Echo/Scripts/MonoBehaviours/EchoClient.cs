using PinionCyber.NetCode.Samples.Echo.Protocols;
using Regulus.Remote.Client;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Echo
{
    public class EchoClient : MonoBehaviour
    {
        public TMPro.TMP_InputField Port;
        public TMPro.TMP_InputField Address;
        public TMPro.TMP_Text Message;

        public EchoEcho EchoEcho;
        private TcpConnectSet _Set;
        readonly System.Collections.Concurrent.ConcurrentQueue<bool> _ConnectResults;
        public EchoClient()
        {
            _ConnectResults = new System.Collections.Concurrent.ConcurrentQueue<bool>();
        }
        public async void Connect()
        {
            if(_Set != null)
            {
                _Set.Agent.Dispose();
                await _Set.Connecter.Disconnect();
                _Set = null;
            }
            var protocol = Protocols.ProtocolCreator.Create();
            _Set = Regulus.Remote.Client.Provider.CreateTcpAgent(protocol);
            _Set.Agent.QueryNotifier<Protocols.IEchoable>().Supply += _ShowEcho;
            var result = await _Set.Connecter.Connect(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(Address.text) , int.Parse(Port.text)));
            _ConnectResults.Enqueue(result);
        }

        private void _ShowEcho(IEchoable echo)
        {
            EchoEcho.Show(echo);
        }

        public void Update()
        {
            bool connectResult;
            while (_ConnectResults.TryDequeue(out connectResult))
            {
                Message.text = connectResult ? "Ok" :"Fail";
            }

            _Set?.Agent.Update();
        }

        private void Start()
        {
            EchoEcho.Hide();
        }
    }

}
