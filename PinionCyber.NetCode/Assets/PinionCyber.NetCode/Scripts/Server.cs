using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinionCyber.NetCode
{
    namespace Codes
    {
    }
    
    public class Server : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var protocol = PinionCyber.NetCode.Codes.ProtocolCreator.Create();
            Debug.Log(protocol.Base);

        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
