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
    public class ClientRepository : AbstractRepository<Client, int>, IClientRepository
    {
        public ClientRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(Client value) => value.Id;

        protected override Client ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<Client> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(Client value)
        {
            _context.Clients.Add(value);
        }
        protected override async Task CreateImplementationAsync(Client value)
        {
            await _context.Clients.AddAsync(value);
        }


        protected override void UpdateImplementation(Client entity, Client value)
        {
            _context.ChangeTracker.Clear();
            _context.Update(value);
        }
        protected override void DeleteImplementation(Client value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.Clients.Remove(entity);
        }


        protected override IQueryable<Client> QueryImplementation()
        {
            return _context.Clients
                .Include(client => client.City)
                .Include(client => client.Gender);
        }
        #endregion
    }
}
