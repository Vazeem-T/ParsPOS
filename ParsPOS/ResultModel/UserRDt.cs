using ParsPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ResultModel
{
    public class UserRDt
    {
        public List<User>? User { get; set; }
        public List<Rights>? Rights { get; set; }
        public List<RightNode>? RightNode { get; set; }
    }
}
