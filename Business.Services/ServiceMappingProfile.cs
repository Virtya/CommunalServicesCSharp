using AutoMapper;
using Business.Entities;
using Business.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Contract, ContractDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Law, LawDto>();
            CreateMap<PaymentDoс, PaymentDocDto>();
            CreateMap<Service, ServiceDto>();

            CreateMap<CityDto, City>();
            CreateMap<ClientDto, Client>();
            CreateMap<ContractDto, Contract>();
            CreateMap<GenderDto, Gender>();
            CreateMap<LawDto, Law>();
            CreateMap<PaymentDocDto, PaymentDoс>();
            CreateMap<ServiceDto, Service>();
        }
    }
}
