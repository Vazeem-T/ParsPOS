using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Model
{
    public class ItmImage
    {
        public string ByteBase64 { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        [ForeignKey(nameof(Invitm))]
        public int InvItmId { get; set; }
    }
}
