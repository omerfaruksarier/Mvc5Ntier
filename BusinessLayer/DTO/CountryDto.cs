using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class CountryDto
    {
        public int? CountryId { get; set; }
        public string CountryName { get; set; }

        public string Capital { get; set; }

        public string Currency { get; set; }

        public string CountryCa { get; set; }
    }
}
