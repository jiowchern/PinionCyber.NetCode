using UnityEngine;
using System.Linq;
using System.Net;
using System;

namespace PinionCyber.NetCode.Status
{
}
namespace PinionCyber.NetCode
{
    public class TcpAgent : MonoBehaviour
    {
        public ProtocolGetter Prococol;

        readonly Regulus.Utility.StatusMachine _Machine;
        readonly static System.Net.Sockets.AddressFamily[] _Accepts = new System.Net.Sockets.AddressFamily[] {
            System.Net.Sockets.AddressFamily.InterNetwork ,
            System.Net.Sockets.AddressFamily.InterNetworkV6
        };

        public UnityEngine.Events.UnityEvent<Regulus.Remote.INotifierQueryable> ReadyEvent;

        public void Connect(object point)
        {
            throw new NotImplementedException();
        }

        public UnityEngine.Events.UnityEvent<Exception> ConnectFailEvent;
        public UnityEngine.Events.UnityEvent<System.Net.Sockets.SocketError> SocketBreakEvent;
        public TcpAgent()
        {
            SocketBreakEvent = new UnityEngine.Events.UnityEvent<System.Net.Sockets.SocketError>();
            ConnectFailEvent = new UnityEngine.Events.UnityEvent<Exception>();
            ReadyEvent = new UnityEngine.Events.UnityEvent<Regulus.Remote.INotifierQueryable>();
            _Machine = new Regulus.Utility.StatusMachine();
        }
        private void Update()
        {
            _Machine.Update();
        }
        public void Disconnect()
        {
            _ToIdle();
        }
        public void Connect(System.Net.EndPoint point)
        {
            
            if(!_Accepts.Any(a => a == point.AddressFamily))
                throw new System.NotSupportedException($"Unsupported {point.AddressFamily}.");
            var socket = new System.Net.Sockets.Socket(point.AddressFamily, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
            _ToConnect(socket , point);
        }

        private void _ToConnect(System.Net.Sockets.Socket socket, EndPoint point)
        {
            var status = new PinionCyber.NetCode.Status.TcpConnect(socket , point);
            status.SuccessEvent += ()=> _ConnectSuccess(socket);
            status.ExceptionEvent += _ConnectFail;
            _Machine.Push(status);
        }

        private void _ConnectFail(Exception obj)
        {
            UnityEngine.Debug.Log($"connect fail:{obj}");
            ConnectFailEvent.Invoke(obj);
            _ToIdle();
        }

        private void _ConnectSuccess(System.Net.Sockets.Socket socket)
        {
            _ToRunnning(socket);
        }

        private void _ToRunnning(System.Net.Sockets.Socket socket)
        {
            var peer = new Regulus.Network.Tcp.Peer(socket);
            
            var agent = Regulus.Remote.Client.Provider.CreateAgent(Prococol.GetProtocol(), peer);
            ReadyEvent.Invoke(agent);
            var status = new PinionCyber.NetCode.Status.AgentUpdater(agent, peer);
            status.SocketErrorEvent += (e) => {
                UnityEngine.Debug.Log($"peer break:{e}");
                SocketBreakEvent.Invoke(e);
                _ToIdle();
            };
            _Machine.Push(status);
        }

        private void _ToIdle()
        {
            
            _Machine.Empty();
        }
        private void OnDestroy()
        {
            _Machine.Termination();
        }
    }

}
