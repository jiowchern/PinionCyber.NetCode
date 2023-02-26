using Regulus.Remote;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Echo
{

    public class EchoEntry : PinionCyber.NetCode.EntryGetter,  Regulus.Remote.IEntry
    {
        readonly System.Collections.Generic.List<User> _Users;

        public UnityEngine.UI.Text Message;
        public EchoEntry()
        {
            _Users = new System.Collections.Generic.List<User>();
        }


        public void Ready()
        {
            Message.text = "ready";
        }
        public override IEntry GetEntry()
        {
            
            return this;
        }

        void Regulus.Remote.IBinderProvider.AssignBinder(Regulus.Remote.IBinder binder)
        {
            binder.BreakEvent += () => {
                UnityEngine.Debug.Log("server break");
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
                    Message.text = $"users:{_Users.Count}";
                }

            };
            lock(_Users)
            {
                
                _Users.Add(new User(binder));
                Message.text = $"users:{_Users.Count}";
            }
                
        }

        
    }
}
