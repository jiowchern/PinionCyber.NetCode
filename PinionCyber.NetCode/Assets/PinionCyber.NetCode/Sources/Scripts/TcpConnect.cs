using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Regulus.Utility;

namespace PinionCyber.NetCode.Status
{
    class TcpConnect : Regulus.Utility.IStatus
    {

        public event System.Action SuccessEvent;
        public event System.Action<Exception> ExceptionEvent;

        private readonly Socket _Socket;
        readonly IAsyncResult _AsyncResult;
        public TcpConnect(Socket socket, EndPoint point)
        {
            _Socket = socket;
            _AsyncResult =  socket.BeginConnect(point, null, null);
        }

        

        void IStatus.Enter()
        {
            
            
        }

        void IStatus.Leave()
        {
            
        }

        void IStatus.Update()
        {
            if (!_AsyncResult.IsCompleted)
                return;
            try
            {
                _Socket.EndConnect(_AsyncResult);
                SuccessEvent();
            }
            catch (Exception e)
            {
                ExceptionEvent(e);                
            }
            
        }
    }
}
