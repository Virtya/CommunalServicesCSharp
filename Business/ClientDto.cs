using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interop
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string PassportSeriesAndNumber { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public virtual CityDto City { get; set; }
        public int? CityId { get; set; }
        public virtual GenderDto Gender { get; set; }
        public int? GenderId { get; set; }
    }
}
