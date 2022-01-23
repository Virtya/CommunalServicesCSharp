using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface IGenderService
    {
        public IEnumerable<GenderDto> GetAll();
    }
}
