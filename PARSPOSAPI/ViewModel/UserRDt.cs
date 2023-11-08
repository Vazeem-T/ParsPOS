using System.Diagnostics.CodeAnalysis;

namespace PARSPOSAPI.ViewModel
{
    public class UserRDt
    {
        public IEnumerable<dynamic>? User {  get; set; }
        public IEnumerable<dynamic>? Rights { get; set; }
        public IEnumerable<dynamic>? RightNode { get; set; }
    }
}
