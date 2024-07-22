using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Bootcamp Bitirme projesi Asp.Net core, css, html, C#",
                Content = "Ben Ahmet Demircan, 1999 doğumlu Elektrik-Elektronik Mühendisi olarak 12. Hava Ulaştırma Ana Üs Komutanlığı ve Halkbank'ta staj yapmış," +
                "Nuh Naci Yazgan Üniversitesi'nde eğitim görmüştür. Ayrıca, Fontys Uygulamalı Bilimler Üniversitesi'nde bir değişim programına katılmıştır. " +
                "Yazılım alanına özel bir ilgisi olup Python,MATLAB ve SQL gibi programlama dillerinde becerilere sahip biriyim. " +
                "proje katıldığım bootcampın bitirme projesidir. Projemde bana bilgileri ile ışık tutan Eğitmenim Ahmet Kaya'ya teşekürlerimi sunarım.",
                WiewCount = 15, //ViewCount yanlışlık ile W ile yazılmış kaynaktan düzeltilmeli veya hep yanlış kullanılmalı.//
                CategoryId = Guid.Parse("5F5A16E6-6E5F-41DE-9DDB-7BD36B0A8654"),
                ImageId = Guid.Parse("AB232908-ACEC-46E0-A328-AF39EADDB236"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}