using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern.Data.Context;

namespace RepositoryPattern.Data.Extensions
{
    public static class DataExtensions
    {
        // public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration){


        //     services.AddDbContext<AppDbContext>(options=>{
        //         options.UseMySql(configuration.GetConnectionString("Default"), ServerVersion.AutoDetect(configuration.GetConnectionString("Default")));
        //     });

        //     return services;
        // }
        
    }
}