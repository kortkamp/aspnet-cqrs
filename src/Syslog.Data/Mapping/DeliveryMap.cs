using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Syslog.Domain.Entities;

namespace Syslog.Data.Mapping
{
    public class DeliveryMap : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("deliveries");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.State).IsRequired();
            builder.Property(x => x.DeliverymanId);
            builder.Property(x => x.DeliveredAt);
            builder.Property(x => x.DeliveredTo);
            builder.HasMany<DeliveryEvent>(x => x.Events);
        }
    }
}