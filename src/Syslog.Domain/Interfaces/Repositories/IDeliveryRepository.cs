using Syslog.Domain.Entities;
namespace Syslog.Domain.Interfaces.Repositories
{
    public interface IDeliveryRepository
    {
        Task<Delivery> GetById(Guid Id);
        Task<Delivery> Save(Delivery delivery);
    }
}