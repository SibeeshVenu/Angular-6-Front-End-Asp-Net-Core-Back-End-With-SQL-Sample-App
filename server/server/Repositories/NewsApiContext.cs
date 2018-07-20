using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class NewsApiContext : DbContext, INewsApiContext
    {
        public DbSet<News> News { get; set; }

        public NewsApiContext(DbContextOptions<NewsApiContext> options):base(options)
        {

        }
    }
}
