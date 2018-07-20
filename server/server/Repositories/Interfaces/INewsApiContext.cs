using Microsoft.EntityFrameworkCore;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Interfaces
{
    public interface INewsApiContext
    {
        DbSet<News> News { get; set; }
    }
}
