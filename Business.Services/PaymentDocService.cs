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
    public class PaymentDocService : IPaymentDocService
    {
        private readonly IPaymentDocRepository _paymentDocRepository;
        private readonly IMapper _mapper;

        public PaymentDocService(IPaymentDocRepository payDocRepository, IMapper mapper)
        {
            _paymentDocRepository = payDocRepository;
            _mapper = mapper;
        }

        public PaymentDocDto CreateOrUpdate(PaymentDocDto payDoc)
        {
            var payDocEnt = _mapper.Map<PaymentDoс>(payDoc);
            _paymentDocRepository.CreateOrUpdate(payDocEnt);
            return _mapper.Map<PaymentDocDto>(payDocEnt);
        }

        public PaymentDocDto CreatePaymentDoc(PaymentDocDto doc)
        {
            var payDocEnt = _mapper.Map<PaymentDoс>(doc);
            _paymentDocRepository.Create(payDocEnt);
            return _mapper.Map<PaymentDocDto>(payDocEnt);
        }

        public void Delete(int id)
        {
            var payDocEnt = _paymentDocRepository.Read(id);
            _paymentDocRepository.Delete(payDocEnt);
        }

        public IEnumerable<PaymentDocDto> GetAll()
        {
            var payDocEnt = _paymentDocRepository.Query();
            return _mapper.Map<IEnumerable<PaymentDoс>, IEnumerable<PaymentDocDto>>(payDocEnt);
        }

        public PaymentDocDto GetById(int id)
        {
            var payDocEnt = _paymentDocRepository.Read(id);
            return _mapper.Map<PaymentDocDto>(payDocEnt);
        }

        public PaymentDocDto Update(PaymentDocDto payDoc)
        {
            var payDocEnt = _mapper.Map<PaymentDoс>(payDoc);
            _paymentDocRepository.Update(payDocEnt);
            return _mapper.Map<PaymentDocDto>(payDocEnt);
        }
    }
}
