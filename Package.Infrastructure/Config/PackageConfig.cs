using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Package.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Infrastructure.Config
{
    public class PackageConfig: IEntityTypeConfiguration<PackageEntity>
    {
        public void Configure(EntityTypeBuilder<PackageEntity> builder)
        {
            builder.ToTable("Package");
            builder.HasKey(e => e.Id);
        }
}
}
