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
    public class CityRepository : AbstractRepository<City, int>, ICityRepository
    {
        public CityRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(City value) => value.Id;

        protected override City ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<City> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(City value)
        {
            _context.Cities.Add(value);
        }
        protected override async Task CreateImplementationAsync(City value)
        {
            await _context.Cities.AddAsync(value);
        }


        protected override void UpdateImplementation(City entity, City value)
        {
            _context.Update(value);
        }
        protected override void DeleteImplementation(City value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Cities.Remove(entity);
        }


        protected override IQueryable<City> QueryImplementation()
        {
            return _context.Cities;
        }
        #endregion
    }
}
