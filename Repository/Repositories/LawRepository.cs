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
    public class LawRepository : AbstractRepository<Law, int>, ILawRepository
    {
        public LawRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(Law entity) => entity.Id;

        protected override Law ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Law> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Law value)
        {
            _context.Laws.Add(value);
        }
        protected override async Task CreateImplementationAsync(Law value)
        {
            await _context.Laws.AddAsync(value);
        }

        protected override void UpdateImplementation(Law entity, Law value)
        {
            _context.Update(value);
        }

        protected override void DeleteImplementation(Law value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Laws.Remove(entity);
        }

        protected override IQueryable<Law> QueryImplementation()
        {
            return _context.Laws;
        }
        #endregion
    }
}
