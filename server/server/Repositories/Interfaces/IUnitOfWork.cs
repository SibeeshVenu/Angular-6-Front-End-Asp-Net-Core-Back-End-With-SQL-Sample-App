using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        INewsRepository News { get; set; }
        int Complete();
    }
}
