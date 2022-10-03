using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UniRx;
namespace PinionCyber.NetCode
{
    public class Sample : MonoBehaviour
    {
        public Entry Entry;
        public int Port;
        public string Address;
        readonly UniRx.CompositeDisposable _Disposables;
        Regulus.Remote.Server.TcpListenSet _ListenSet;
        public Sample()
        {
            _Disposables = new CompositeDisposable();
        }
        // Start is called before the first frame update
        void Start()
        {
            var protocol = PinionCyber.NetCode.ProtocolCreator.Create();
            Debug.Log(protocol.Base);

            _ListenSet = Regulus.Remote.Server.Provider.CreateTcpService(Entry , protocol);
            var agentSet = Regulus.Remote.Client.Provider.CreateTcpAgent(protocol);
            var agent = agentSet.Agent;
            _Disposables.Add( UniRx.Observable.EveryUpdate().Subscribe(delta => agent.Update()));
            _ListenSet.Listener.Bind(Port);



            var obs = from connectResult in agentSet.Connecter.Connect(new System.Net.IPEndPoint(System.Net.IPAddress.Parse(Address), Port)).ToObservable()
                      where connectResult == true
                      from e in UniRx.Observable.FromEvent<IEchoable>(
                          (h) => agentSet.Agent.QueryNotifier<IEchoable>().Supply += h,
                          (h) => agentSet.Agent.QueryNotifier<IEchoable>().Supply -= h
                          )
                      let remoteValue = e.Echo("123")
                      let eventObs = UniRx.Observable.FromEvent<string>(
                          (h) => remoteValue.OnValue += h,
                          (h) => remoteValue.OnValue -= h
                          )
                      from echoMessage in eventObs
                      select echoMessage;
          _Disposables.Add(obs.ObserveOnMainThread().Subscribe(msg => UnityEngine.Debug.Log("echo:" + msg)));

            
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnDestroy()
        {
            
            _Disposables.Clear();
        }
    }
}
