using System;

namespace PinionCyber.NetCode
{
    class DisposeSet : System.IDisposable
    {
        public readonly System.Collections.Generic.List<System.IDisposable> Disposes;

        public DisposeSet()
        {
            Disposes = new System.Collections.Generic.List<IDisposable> ();
        }
        public void Dispose()
        {
            foreach (var item in Disposes)
            {
                item.Dispose();
            }
        }
    }
}
