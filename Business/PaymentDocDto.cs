using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interop
{
    public class PaymentDocDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ContractDto Contract { get; set; }
        public int? ContractId { get; set; }
        public virtual ClientDto Client { get; set; }
        public int? ClientId { get; set; }
    }
}
