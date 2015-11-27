using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huwax.Dal;
using Infrastructure.Interfaces;

namespace Infrastructure.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private HuwaxEntities _context;

        public HuwaxEntities Get()
        {
            return _context ?? (_context = new HuwaxEntities());
        }

        protected override void DisposeCore()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
