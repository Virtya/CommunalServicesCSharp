using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class PaymentDoс
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
