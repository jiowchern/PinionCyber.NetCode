using Regulus.Remote.Server;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Echo
{
    public class EchoServer : MonoBehaviour
    {
        public EchoEntry _Entry;
        public TMPro.TMP_InputField Port;
        public TMPro.TMP_Text _Message;
        TcpListenSet _Set;
        public void Listen()
        {
            if(_Set != null)
            {
                
                _Set.Listener.Close();
                _Set.Service.Dispose();
                _Message.text = "";
            }
            var protocol = Protocols.ProtocolCreator.Create();
            _Set = Regulus.Remote.Server.Provider.CreateTcpService(_Entry, protocol);
            _Set.Listener.Bind(int.Parse(Port.text));
            _Message.text = "Ok";
        }
    }

}
