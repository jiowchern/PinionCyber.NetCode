using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PinionCyber.NetCode.Helpers
{
    public class UITextToTcpBind : MonoBehaviour
    {
        public UnityEngine.UI.Text Text;
        public TcpListener Listener;

        public void Bind()
        {
            int port;
            if (!int.TryParse(Text.text, out port))
                return;
            Listener.Bind(port);
        }
    }

}
