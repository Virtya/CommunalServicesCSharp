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
    public class GenderRepository : AbstractRepository<Gender, int>, IGenderRepository
    {
        public GenderRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(Gender entity) => entity.Id;

        protected override Gender ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Gender> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Gender value)
        {
            _context.Genders.Add(value);
        }
        protected override async Task CreateImplementationAsync(Gender value)
        {
            await _context.Genders.AddAsync(value);
        }

        protected override void UpdateImplementation(Gender entity, Gender value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Gender value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Genders.Remove(entity);
        }

        protected override IQueryable<Gender> QueryImplementation()
        {
            return _context.Genders;
        }
        #endregion
    }
}
