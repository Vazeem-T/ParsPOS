using ParsVanSale.Model;

namespace ParsVanSale.RModel
{
    public class UserRDt
    {
        public List<User>? User { get; set; }
        public List<Rights>? Rights { get; set; }
        public List<RightNode>? RightNode { get; set; }
    }
}
