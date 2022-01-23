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
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public IEnumerable<GenderDto> GetAll()
        {
            var genders = _genderRepository.Query();
            return _mapper.Map<IEnumerable<Gender>, IEnumerable<GenderDto>>(genders);
        }
    }
}
