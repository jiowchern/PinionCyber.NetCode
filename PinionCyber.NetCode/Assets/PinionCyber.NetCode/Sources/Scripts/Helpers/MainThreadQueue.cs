namespace PinionCyber.NetCode
{
    public class MainThreadQueue :UnityEngine.MonoBehaviour
    {
        public delegate void OnAction();

        static readonly System.Collections.Concurrent.ConcurrentQueue<OnAction> _Actions = new System.Collections.Concurrent.ConcurrentQueue<OnAction>();
       
        [UnityEngine.RuntimeInitializeOnLoadMethod]
        public static void Initial()
        {
            var obj = new UnityEngine.GameObject("PinionCyber.NetCode.MainThreadQueue");
            obj.AddComponent<MainThreadQueue>();
            
        }
        public static void Post(OnAction action)
        {
            _Actions.Enqueue(action);            
        }

        public void Update()
        {
            while(_Actions.TryDequeue(out var action))
            {
                action();
            }
        }
    }

}
