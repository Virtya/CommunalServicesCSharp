using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public int PayableAmount { get; set; }
        public DateTime PaymentTerm { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int? LawId { get; set; }
        public virtual Law Law { get; set; }
    }
}
