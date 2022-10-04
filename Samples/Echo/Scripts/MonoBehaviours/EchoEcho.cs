using PinionCyber.NetCode.Samples.Echo.Protocols;
using UnityEngine;

namespace PinionCyber.NetCode.Samples.Echo
{
    public class EchoEcho : MonoBehaviour     
    {
        public GameObject Root;
        public UnityEngine.UI.InputField Request;        
        public UnityEngine.UI.Text Response;
        IEchoable _Echo;
        public void Show(IEchoable echo)
        {
            _Echo= echo;
            Root.SetActive(true);
        }


        public async void  Send()
        {
            var response = await _Echo.Echo(Request.text);
            Response.text = response;
        }

        internal void Hide()
        {
            Root.SetActive(false);
        }
    }

}
