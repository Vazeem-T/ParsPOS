using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class LoadingService
    {
        private bool isDownloading = false;

        public bool IsDownloading
        {
            get { return isDownloading; }
            set
            {
                isDownloading = value;
            }
        }
    }
}
