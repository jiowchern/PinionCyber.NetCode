using UnityEngine;

namespace PinionCyber.NetCode
{
    public class Agent : MonoBehaviour
    {
        public StreamGetter Connector;
        public ProtocolGetter Prococol;
        Regulus.Remote.Ghost.IAgent _Agent;
        System.Action _Update;
        public UnityEngine.Events.UnityEvent<Regulus.Remote.INotifierQueryable> ReadyEvent;
        public Agent()
        {
            ReadyEvent = new UnityEngine.Events.UnityEvent<Regulus.Remote.INotifierQueryable>();
            _Update = () => { };
        }
        public void Start()
        {
            _Release();
            var protocol = Prococol.GetProtocol();
            var agent = Regulus.Remote.Client.Provider.CreateAgent(protocol, Connector.GetStream(), new Regulus.Remote.Serializer(protocol.SerializeTypes));
            _Agent = agent;
            _Update = () => _Agent.Update();
            ReadyEvent.Invoke(_Agent);
        }

        private void _Release()
        {
            if (_Agent != null)
            {
                _Update = () => { };
                _Agent.Dispose();
                _Agent = null;
            }
        }

        public void Update()
        {
            _Update();
        }

        public void OnDestroy()
        {
            _Release();   
        }
    }

}
