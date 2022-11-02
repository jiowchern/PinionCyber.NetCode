using Regulus.Remote;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinionCyber.NetCode
{

   
    public class Service : MonoBehaviour
    {

        
        public EntryGetter Entry;
        public ProtocolGetter Protocol;
        public ListenerGetter Listener;
        Regulus.Remote.Soul.SyncService _Service;
        // Start is called before the first frame update
        void Start()
        {
            var protocol = Protocol.GetProtocol();
            var userProvider = new Regulus.Remote.Soul.UserProvider(protocol, new Regulus.Remote.Serializer(protocol.SerializeTypes) , Listener.GetListener() , new Regulus.Remote.InternalSerializer());
            _Service = new Regulus.Remote.Soul.SyncService(Entry.GetEntry(), userProvider);
        }

        // Update is called once per frame
        void Update()
        {
            _Service.Update();
        }

        private void OnDestroy()
        {
            System.IDisposable disposable = _Service;
            disposable.Dispose();
        }
    }

}
