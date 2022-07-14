using System.Linq;
using DataAccess.Entities;

namespace DataAccess.Repository.DeliveryRepository
{
    public class DeliveryRepository : Repository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(WMSDatabaseContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Delivery> GetQueryableEntity()
        {
            return Entity.AsQueryable();
        }
    }
}