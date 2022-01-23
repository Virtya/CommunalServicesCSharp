using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface IServiceService
    {
        public ServiceDto CreateService(ServiceDto service);
        public IEnumerable<ServiceDto> GetAll();
        public ServiceDto CreateOrUpdate(ServiceDto service);
        public ServiceDto GetById(int id);
        public ServiceDto Update(ServiceDto service);
        public void Delete(int id);
    }
}
