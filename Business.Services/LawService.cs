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
    public class LawService : ILawService
    {
        private readonly ILawRepository _lawRepository;
        private readonly IMapper _mapper;

        public LawService(ILawRepository lawRepository, IMapper mapper)
        {
            _lawRepository = lawRepository;
            _mapper = mapper;
        }

        public IEnumerable<LawDto> GetAll()
        {
            var laws = _lawRepository.Query();
            return _mapper.Map<IEnumerable<Law>, IEnumerable<LawDto>>(laws);
        }
    }
}
