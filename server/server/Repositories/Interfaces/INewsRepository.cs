using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Interfaces
{
    public interface INewsRepository: IRepository<News>
    {
        string GetAllNewsFromNewsDb(string searchType, string q, string category);
    }
}
