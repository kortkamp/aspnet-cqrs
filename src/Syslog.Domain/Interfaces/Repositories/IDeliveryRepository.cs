using CqrsPoc.Domain.Entities;

namespace CqrsPoc.Domain.Interfaces.Repositories
{
    public interface IDeliveryRepository
    {
        Task<Delivery> GetById(Guid Id);
        Task<Delivery> Save(Delivery delivery);
    }
}