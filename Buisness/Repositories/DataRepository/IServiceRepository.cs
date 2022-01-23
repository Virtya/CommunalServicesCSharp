using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Business.Interop;

namespace Business.Repositories.DataRepository
{
    public interface IServiceRepository : IRepository<Service, int>
    {
    }
}
