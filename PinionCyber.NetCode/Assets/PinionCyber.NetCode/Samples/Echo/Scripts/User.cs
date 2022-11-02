using PinionCyber.NetCode.Samples.Echo.Protocols;
using Regulus.Remote;

namespace PinionCyber.NetCode.Samples.Echo
{
    public class User: Protocols.Echoable ,System.IDisposable
    {
        public readonly Regulus.Remote.IBinder Binder;
        private readonly ISoul _Soul;
        private bool disposedValue;

        public User(Regulus.Remote.IBinder  binder)
        {
            Binder = binder;
            _Soul = Binder.Bind<Protocols.Echoable>(this);
        }

        Value<string> Protocols.Echoable.Echo(string message)
        {
            return "echo:" + message;
        }


        public void Dispose()
        {
            Binder.Unbind(_Soul);
        }

     
    }
}
