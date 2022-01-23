using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Interop;
using Business.Repositories.DataRepository;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, ICityRepository cityRepository, IGenderRepository genderRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _cityRepository = cityRepository;
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public ClientDto CreateClient(ClientDto client)
        {
            var clientEnt = _mapper.Map<Client>(client);
            _clientRepository.Create(clientEnt);
            return _mapper.Map<ClientDto>(clientEnt);
        }

        public ClientDto CreateOrUpdate(ClientDto client)
        {
            var clientEnt = _mapper.Map<Client>(client);
            _clientRepository.CreateOrUpdate(clientEnt);
            return _mapper.Map<ClientDto>(clientEnt);
        }

        public void Delete(int id)
        {
            var clientEnt = _clientRepository.Read(id);
            _clientRepository.Delete(clientEnt);
        }

        public IEnumerable<ClientDto> FindByFIO(string fio)
        {
            var clients = _clientRepository.Query()
               .Where(element => element.FIO.Contains(fio, StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Client>, IEnumerable < ClientDto>>(clients);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            var clients = _clientRepository.Query();
            return _mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(clients);
        }

        public ClientDto GetById(int id)
        {
            var clientEnt = _clientRepository.Read(id);
            return _mapper.Map<ClientDto>(clientEnt);
        }

        public ClientDto Update(ClientDto client)
        {
            var clientEnt = _mapper.Map<Client>(client);
            _clientRepository.Update(clientEnt);
            return _mapper.Map<ClientDto>(clientEnt);
        }
    }
}
