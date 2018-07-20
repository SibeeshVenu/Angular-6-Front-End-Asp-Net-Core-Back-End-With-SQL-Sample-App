using server.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public INewsRepository News { get; set; }
        private NewsApiContext _context { get; }

        public UnitOfWork(NewsApiContext newsApiContext)
        {
            _context = newsApiContext;
            News = new NewsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
