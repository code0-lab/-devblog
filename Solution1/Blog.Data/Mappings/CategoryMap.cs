using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category = new Category
            {
                Id = Guid.Parse("5F5A16E6-6E5F-41DE-9DDB-7BD36B0A8654"),
                Name = "Bootcamp Bitirme projesi",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
        
        }
    }
}
