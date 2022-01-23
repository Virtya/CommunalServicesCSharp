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
    public class ContractRepository : AbstractRepository<Contract, int>, IContractRepository
    {
        public ContractRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(Contract value) => value.Id;

        protected override Contract ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Contract> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Contract value)
        {
            _context.Contracts.Add(value);
        }
        protected override async Task CreateImplementationAsync(Contract value)
        {
            await _context.Contracts.AddAsync(value);
        }


        protected override void UpdateImplementation(Contract entity, Contract value)
        {
            _context.ChangeTracker.Clear();
            _context.Update(value);
        }
        protected override void DeleteImplementation(Contract value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Contracts.Remove(entity);
        }


        protected override IQueryable<Contract> QueryImplementation()
        {
            return _context.Contracts
                .Include(contract => contract.Client)
                    .ThenInclude(address => address.City)
                .Include(contract => contract.Client)
                    .ThenInclude(client => client.Gender)
                .Include(contract => contract.Law)
                .Include(contract => contract.Service);
        }
        #endregion
    }
}
