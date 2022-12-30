using System;
using System.Net.Sockets;
using Regulus.Network.Tcp;
using Regulus.Remote.Ghost;
using Regulus.Utility;


namespace PinionCyber.NetCode.Status
{
    class AgentUpdater : Regulus.Utility.IStatus
    {
        private readonly IAgent _Agent;
        private readonly Peer _Peer;
        readonly DisposeSet _DisposeSet;
        System.Nullable<SocketError> _SocketError;
        public event System.Action<SocketError> SocketErrorEvent;
        public AgentUpdater(IAgent agent,Peer peer)
        {
            _DisposeSet = new DisposeSet();
            _DisposeSet.Disposes.Add(agent);
            _DisposeSet.Disposes.Add(peer);
            this._Agent = agent;
            this._Peer = peer;
        }

        void IStatus.Enter()
        {
            _Peer.SocketErrorEvent += _Break;
        }

        void IStatus.Leave()
        {
            _Peer.SocketErrorEvent -= _Break;
            if (_Peer.Socket.Connected)
                _Peer.Socket.Shutdown(SocketShutdown.Both);
            _Peer.Socket.Disconnect(false);
            _Peer.Socket.Close();            
            _DisposeSet.Dispose();
            
        }

        private void _Break(SocketError obj)
        {
            _SocketError = obj;
        }

        void IStatus.Update()
        {
            if(_SocketError.HasValue)
            {
                SocketErrorEvent(_SocketError.Value);
                return;
            }
            _Agent.Update();
        }
    }
}
