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
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IMapper _mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _mapper = mapper;
        }

        public ContractDto CreateContract(ContractDto contract)
        {
            var contractEnt = _mapper.Map<Contract>(contract);
            _contractRepository.Create(contractEnt);
            return _mapper.Map<ContractDto>(contractEnt);
        }

        public ContractDto CreateOrUpdate(ContractDto contract)
        {
            var contEnt = _mapper.Map<Contract>(contract);
            _contractRepository.CreateOrUpdate(contEnt);
            return _mapper.Map<ContractDto>(contEnt);
        }

        public void Delete(int id)
        {
            var conEnt = _contractRepository.Read(id);
            _contractRepository.Delete(conEnt);
        }

        public IEnumerable<ContractDto> FindByContractNumber(string contructNum)
        {
            var contracts = _contractRepository.Query()
               .Where(element => element.ContractNumber.Contains(contructNum, StringComparison.InvariantCultureIgnoreCase));
            return _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractDto>>(contracts);
        }

        public IEnumerable<ContractDto> GetAll()
        {
            var contracts = _contractRepository.Query();
            return _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractDto>>(contracts);
        }

        public ContractDto GetById(int id)
        {
            var conEnt = _contractRepository.Read(id);
            return _mapper.Map<ContractDto>(conEnt);
        }

        public ContractDto Update(ContractDto contract)
        {
            var conEnt = _mapper.Map<Contract>(contract);
            _contractRepository.Update(conEnt);
            return _mapper.Map<ContractDto>(conEnt);
        }
    }
}
