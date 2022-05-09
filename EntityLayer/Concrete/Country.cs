using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        [StringLength(50)]
        public string CountryName { get; set; }
        [StringLength(50)]
        public string Capital { get; set; }
        [StringLength(50)]
        public string CountryCurrency { get; set; }
        [StringLength(20)]
        public string CountryCa { get; set; }
    }
}
