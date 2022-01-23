using Business.Entities;
using Business.Repositories.DataRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ServiceRepository : AbstractRepository<Service, int>, IServiceRepository
    {
        public ServiceRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(Service entity) => entity.Id;

        protected override Service ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Service> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Service value)
        {
            _context.Services.Add(value);
        }
        protected override async Task CreateImplementationAsync(Service value)
        {
            await _context.Services.AddAsync(value);
        }

        protected override void UpdateImplementation(Service entity, Service value)
        {
            _context.ChangeTracker.Clear();
            _context.Update(value);
        }

        protected override void DeleteImplementation(Service value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Services.Remove(entity);
        }

        protected override IQueryable<Service> QueryImplementation()
        {
            return _context.Services;
        }
        #endregion
    }
}
