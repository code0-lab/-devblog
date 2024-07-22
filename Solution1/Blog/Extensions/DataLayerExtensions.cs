using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Blog.Data.Repositories.Abstractions;
using Blog.Data.Repositories.Concretes;
using Blog.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Extensions
{

        public static class DataLayerExtensions
        {
            public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
            {
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection"))); // Veritabanı bağlantısını ekledik.//
                return services;
            }

        }
    }
