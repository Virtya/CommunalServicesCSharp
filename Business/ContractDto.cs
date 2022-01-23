using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interop
{
    public class ContractDto
    {
        public int Id { get; set; }
        public int ContractNumber { get; set; }
        public int PayableAmount { get; set; }
        public DateTime PaymentTerm { get; set; }
        public virtual ServiceDto Service { get; set; }
        public int? ServiceId { get; set; }
        public virtual ClientDto Client { get; set; }
        public int? ClientId { get; set; }
        public int? LawId { get; set; }
        public virtual LawDto Law { get; set; }
    }
}
