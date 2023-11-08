using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class Rights
    {
        public int? Id { get; set; }
        public bool RightYN { get; set; }
        public bool IsMenu { get; set; }
        public string ProcessCode { get; set; }
        public int? NodeId { get; set; }
        public bool IsVisible { get; set; }
    }
}
