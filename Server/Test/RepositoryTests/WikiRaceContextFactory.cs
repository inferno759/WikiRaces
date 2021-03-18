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

        public Data.Entities.Project2Context CreateContext()
        {
            if (_conn == null)
            {
                _conn = new SqliteConnection("DataSource=:memory:");
                _conn.Open();

                DbContextOptions<Data.Entities.Project2Context> options = CreateOptions();
                using var context = new Data.Entities.Project2Context(options);
                context.Database.EnsureCreated();

                // add extra test seed data here (or, in each test method)
            }

            return new Data.Entities.Project2Context(CreateOptions());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _conn.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
