using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CieDigitalAssessment.DAL
{

    // We make the generic repository interface to allow us to implement
    // a mock interface for testing
    public interface IApplicationRepository<T> : IDisposable
    {
        IQueryable<T> Get();

        T Get(int id);

        void Create(T record);

        void Update(T record);

        void Delete(int id);

        int Save();

        Task<int> SaveAsync();
    }
}
