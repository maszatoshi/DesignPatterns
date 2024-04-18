using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    sealed class UploadService
    {
        private UploadService() { }

        private static UploadService _instance;

        private static readonly object _instanceLock = new object();

        public static UploadService Instance()
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    _instance = new UploadService();
                }
            }
                

            return _instance;
        }
    }
}
