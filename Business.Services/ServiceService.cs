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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public ServiceDto CreateOrUpdate(ServiceDto service)
        {
            var serEnt = _mapper.Map<Service>(service);
            _serviceRepository.CreateOrUpdate(serEnt);
            return _mapper.Map<ServiceDto>(serEnt);
        }

        public ServiceDto CreateService(ServiceDto service)
        {
            var serviceEnt = _mapper.Map<Service>(service);
            _serviceRepository.CreateOrUpdate(serviceEnt);
            return _mapper.Map<ServiceDto>(serviceEnt);

        }

        public void Delete(int id)
        {
            var serEnt = _serviceRepository.Read(id);
            _serviceRepository.Delete(serEnt);
        }

        public IEnumerable<ServiceDto> GetAll()
        {
            var services = _serviceRepository.Query();
            return _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceDto>>(services);
        }

        public ServiceDto GetById(int id)
        {
            var serEnt = _serviceRepository.Read(id);
            return _mapper.Map<ServiceDto>(serEnt);
        }

        public ServiceDto Update(ServiceDto service)
        {
            var serEnt = _mapper.Map<Service>(service);
            _serviceRepository.Update(serEnt);
            return _mapper.Map<ServiceDto>(serEnt);
        }
    }
}
