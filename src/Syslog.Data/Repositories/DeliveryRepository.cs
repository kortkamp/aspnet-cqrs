using Microsoft.EntityFrameworkCore;

using Syslog.Data.Context;
using Syslog.Domain.Entities;
using Syslog.Domain.Interfaces.Repositories;

namespace Syslog.Data.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DataContext _dataContext;

        public DeliveryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<Delivery?> GetById(Guid id)
        {
            return _dataContext.Deliveries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Delivery> Save(Delivery delivery)
        {
            var deliveryExists = await GetById(id: delivery.Id);
            if (deliveryExists == null)
            {
                await _dataContext.Deliveries.AddAsync(delivery);
            }
            else
            {
                _dataContext.Deliveries.Update(delivery);
            }

            _dataContext.SaveChanges();

            return delivery;
        }
    }
}