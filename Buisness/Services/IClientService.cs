using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface IClientService
    {
        public ClientDto CreateClient(ClientDto client);
        public IEnumerable<ClientDto> GetAll();
        public ClientDto CreateOrUpdate(ClientDto client);
        public ClientDto GetById(int id);
        public ClientDto Update(ClientDto client);
        public void Delete(int id);
    }
}
