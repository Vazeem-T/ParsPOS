using ParsPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ResultModel
{
    public class PrefixTbCombination
    {
        public IEnumerable<PreFixTb> ButtonPrefix { get; set; }
        public ICommand PrefixCommand { get; set; }
    }
}
