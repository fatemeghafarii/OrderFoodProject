using OrderFood.Domain.Vendors;
using OrderFood.Framework.Persistence.EF;
using OrderFood.Persistence.EF.Contexts;

namespace OrderFood.Persistence.EF.Vendors
{
    public class VendorRepository : BaseRepository<Vendor>
    {
        public VendorRepository(OrderFoodContext orderFoodContext) : base(orderFoodContext)
        {
        }
    }
}
