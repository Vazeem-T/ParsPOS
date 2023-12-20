using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class SharedDispalyTxt
    {
        private string _displayText = string.Empty;

        public string DisplayText
        {
            get { return _displayText; }
            set { _displayText = value; }
        }
    }
}
