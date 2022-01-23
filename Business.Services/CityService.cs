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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public CityDto CreateCity(CityDto city)
        {
            var cityEnt = _mapper.Map<City>(city);
            _cityRepository.CreateOrUpdate(cityEnt);
            return _mapper.Map<CityDto>(cityEnt);
        }

        public IEnumerable<CityDto> GetAll()
        {
            var cities = _cityRepository.Query();
            return _mapper.Map<IEnumerable<City>, IEnumerable<CityDto>>(cities);
        }
    }
}
