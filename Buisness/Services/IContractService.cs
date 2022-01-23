using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface IContractService
    {
        public ContractDto CreateContract(ContractDto contract);
        public IEnumerable<ContractDto> GetAll();
        public IEnumerable<ContractDto> FindByContractNumber(string contructNum);
        public ContractDto CreateOrUpdate(ContractDto contract);
        public ContractDto GetById(int id);
        public ContractDto Update(ContractDto contract);
        public void Delete(int id);
    }
}
