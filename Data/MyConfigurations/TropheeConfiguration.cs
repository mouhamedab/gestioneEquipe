using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.MyConfigurations
{
    public class TropheeConfiguration : IEntityTypeConfiguration<Trophee>
    {
        public void Configure(EntityTypeBuilder<Trophee> builder)
        {
            builder.HasOne(t => t.Equipe).WithMany(e => e.Trophees).HasForeignKey(t => t.EquipeFK).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
