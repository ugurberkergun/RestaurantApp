using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DAL.Concreate.EntityFramework.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(70);

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(x => x.PhotoUrl).IsRequired().HasColumnType("nvarchar").HasMaxLength(300);

            builder.HasOne(x => x.FoodCategory).WithMany(x => x.Foods).HasForeignKey(x => x.CategoryId);
        }
    }
}
