using System;
using System.Collections.Generic;
using System.Text;
using Business.Interop;

namespace Business.Services
{
    public interface IPaymentDocService
    {
        public PaymentDocDto CreatePaymentDoc(PaymentDocDto doc);
        public IEnumerable<PaymentDocDto> GetAll();
        public PaymentDocDto CreateOrUpdate(PaymentDocDto payDoc);
        public PaymentDocDto GetById(int id);
        public  PaymentDocDto Update(PaymentDocDto payDoc);
        public void Delete(int id);
    }
}
