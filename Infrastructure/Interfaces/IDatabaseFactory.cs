using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huwax.Dal;

namespace Infrastructure.Interfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        HuwaxEntities Get();
    }
}
