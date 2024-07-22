using Blog.Data.Mappings;
using Blog.Entity.Entities; // Article.cs dosyasını kullanabilmek için ekledik.//
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Burada article yerine çoğul articles yazıldı.sebei ise veritabanında articles(tabloda birden çok veri var) tablosu oluşturuldu.//
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; } // Category tablosu oluşturuldu.//
       public DbSet<Image> Images { get; set; } // Image tablosu oluşturak boynumuzun borcu.//
    }
}
