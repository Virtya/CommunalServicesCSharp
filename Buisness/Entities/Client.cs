using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string PassportSeriesAndNumber { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public virtual City City { get; set; }
        public int? CityId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? GenderId { get; set; }
    }
}
