using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;

namespace Business.Repositories.DataRepository
{
    public interface IClientRepository : IRepository<Client, int>
    { 
    }
}
