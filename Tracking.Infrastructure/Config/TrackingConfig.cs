using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Infrastructure.Config
{
    public class TrackingConfig: IEntityTypeConfiguration<TrackingEntity>
    {
        public void Configure(EntityTypeBuilder<TrackingEntity> builder)
        {
            builder.ToTable("TrackingLog");
        }
}
}
