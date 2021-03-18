using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Test.RepositoryTests
{
    public class WikiRaceContextFactory : IDisposable
    {
        private DbConnection _conn;
        private bool disposedValue;

        private DbContextOptions<Data.Entities.Project2Context> CreateOptions()
        {
            return new DbContextOptionsBuilder<Data.Entities.Project2Context>().UseSqlite(_conn).Options;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~WikiRaceContextFactory()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
