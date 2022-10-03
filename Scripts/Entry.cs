using Regulus.Remote;
using UnityEngine;
namespace PinionCyber.NetCode
{
    public class Entry : MonoBehaviour ,  Regulus.Remote.IEntry, IEchoable
    {
        void Regulus.Remote.IBinderProvider.AssignBinder(Regulus.Remote.IBinder binder)
        {
            binder.Bind<IEchoable>(this);
        }

        Value<string> IEchoable.Echo(string message)
        {
            return "re:" + message;
        }
    }
}
