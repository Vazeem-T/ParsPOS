using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class RightNode
    {
        public int NodeId {  get; set; }
        public short? ParentId { get; set; }
        public string? Description { get; set; }
        public bool defRight { get; set; }
        public bool isTag { get; set; }
        public bool OnlyPrgmr {  get; set; }
        public short? OrdNo { get; set; }
        public string? ProcessCode {  get; set; }
    }
}
