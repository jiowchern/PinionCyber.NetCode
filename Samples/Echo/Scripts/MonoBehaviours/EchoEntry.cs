using Regulus.Remote;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Echo
{

    public class EchoEntry : MonoBehaviour ,  Regulus.Remote.IEntry
    {
        readonly System.Collections.Generic.List<User> _Users;
        public EchoEntry()
        {
            _Users = new System.Collections.Generic.List<User>();
        }
        void Regulus.Remote.IBinderProvider.AssignBinder(Regulus.Remote.IBinder binder)
        {
            binder.BreakEvent += () => {
                lock(_Users)
                {
                    var removes = new System.Collections.Generic.List<User>();
                    foreach (var user in _Users)
                    {
                        if (user.Binder == binder)
                            continue;
                        user.Dispose();
                        removes.Add(user);                        
                        break;
                    }
                    foreach (var user in removes)
                    {
                        _Users.Remove(user);                        
                    }
                }
            };
            lock(_Users)
            {
                _Users.Add(new User(binder));                
            }
                
        }

        
    }
}
