using Dotz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Data.Configurations
{
    public class UserHistoryConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OperationDate).IsRequired();
            builder.Property(x => x.Operation).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Balance).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserHistories)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
