using CieDigitalAssessment.API.Models;
using CieDigitalAssessment.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieDigitalAssessment.API
{

    // This is a generic repository that gets a DbContext injected to manage the database
    // It is helpful to have this repository pattern to make unit testing easier and to decouple
    // the data access from the business logic
    public class ApplicationRepository<T> : IApplicationRepository<T> where T : class, IEntity
    {
        private DbContext _context;

        public ApplicationRepository(CDLAppContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public T Get(int id)
        {
            return Get().SingleOrDefault(e => e.Id == id);
        }

        public void Create(T record)
        {
            _context.Add(record);
        }

        public void Update(T record)
        {
            _context.Set<T>().Attach(record);
            _context.Entry(record).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var record = Get(id);

            if (record != null)
            {
                 _context.Set<T>().Remove(record);
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
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
                    _context.Dispose();
                    _context = null;
                }
            }
        }
        #endregion
    }
}
