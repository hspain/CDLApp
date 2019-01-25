using CieDigitalAssessment.DAL;
using CieDigitalAssessment.API.Models;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieDigitalAssessment.Test
{
    public class MockRepository<T> : IApplicationRepository<T> where T : class, IEntity
    {
        // From a NuGet package EntityFrameworkCoreMock.  This allows us to use a fake context in our
        // mock repository.  We separate the DB from our tests to allow for more isolated unit tests
        private DbContextMock<CDLAppContext> _context;

        public MockRepository(DbContextMock<CDLAppContext> context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Object.Set<T>();
        }

        public T Get(int id)
        {
            return Get().SingleOrDefault(e => e.Id == id);
        }

        public void Create(T record)
        {
            _context.Object.Add(record);
        }

        public void Update(T record)
        {
            _context.Object.Set<T>().Attach(record);
            _context.Object.Entry(record).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var record = Get(id);

            if (record != null)
            {
                 _context.Object.Set<T>().Remove(record);
            }
        }

        public int Save()
        {
            return _context.Object.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.Object.SaveChangesAsync();
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Object.Dispose();
                    _context = null;
                }
            }
        }
        #endregion
    }
}
