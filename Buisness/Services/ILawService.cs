using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface ILawService
    {
        public IEnumerable<LawDto> GetAll();
    }
}
