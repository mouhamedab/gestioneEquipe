using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Infrastructures
{
    public class Disposable : IDisposable
    {
        bool isDisposed; // tester si la ressource est libérée ou non
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void DisposeCore()
        {

        }
        public void Dispose(bool disposing)
        {
            if(! isDisposed && disposing)
            {
                DisposeCore();
                isDisposed = true;
            }
            
        }
    }
}
