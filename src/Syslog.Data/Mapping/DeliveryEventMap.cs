using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Syslog.Domain.Entities;

namespace Syslog.Data.Mapping
{
    public class DeliveryEventMap : IEntityTypeConfiguration<DeliveryEvent>
    {
        public void Configure(EntityTypeBuilder<DeliveryEvent> builder)
        {
            builder.ToTable("delivery_events");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.State).IsRequired();

            builder.Property(p => p.Date).IsRequired();
        }
    }
}