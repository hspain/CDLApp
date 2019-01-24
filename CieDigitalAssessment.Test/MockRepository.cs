using CieDigitalAssessment.DAL;
using CieDigitalAssessment.Models;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieDigitalAssessment.API
{
    public class MockRepository<T> : IApplicationRepository<T> where T : class, IEntity
    {
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
