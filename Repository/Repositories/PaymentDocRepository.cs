using Business.Entities;
using Business.Repositories.DataRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class PaymentDocRepository : AbstractRepository<PaymentDoс, int>, IPaymentDocRepository
    {
        public PaymentDocRepository(Context context)
        {
            _context = context;
        }

        #region impl
        protected override int KeySelector(PaymentDoс entity) => entity.Id;

        protected override PaymentDoс ReadImpementation(int key)
        {
            return QueryImplementation().FirstOrDefault(element => element.Id == key);
        }
        protected override async Task<PaymentDoс> ReadImpementationAsync(int key)
        {
            return await QueryImplementation().FirstOrDefaultAsync(element => element.Id == key);
        }

        protected override void CreateImplementation(PaymentDoс value)
        {
            _context.PaymentDoсs.Add(value);
        }
        protected override async Task CreateImplementationAsync(PaymentDoс value)
        {
            await _context.PaymentDoсs.AddAsync(value);
        }

        protected override void UpdateImplementation(PaymentDoс entity, PaymentDoс value)
        {
            _context.ChangeTracker.Clear();
            _context.Update(value);
        }

        protected override void DeleteImplementation(PaymentDoс value)
        {
            var entity = ReadImpementation(value.Id);
            if (entity == null)
                return;
            _context.PaymentDoсs.Remove(entity);
        }

        protected override IQueryable<PaymentDoс> QueryImplementation()
        {
            return _context.PaymentDoсs
                .Include(paymentDoc => paymentDoc.Client)
                    .ThenInclude(address => address.City)
                .Include(paymentDoc => paymentDoc.Client)
                    .ThenInclude(client => client.Gender)
                .Include(paymentDoc => paymentDoc.Contract)
                    .ThenInclude(contract => contract.Law)
                .Include(paymentDoc => paymentDoc.Contract)
                    .ThenInclude(contract => contract.Service);
        }
        #endregion
    }
}
