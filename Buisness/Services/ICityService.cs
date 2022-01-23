using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface ICityService
    {
        public IEnumerable<CityDto> GetAll();
    }
}
