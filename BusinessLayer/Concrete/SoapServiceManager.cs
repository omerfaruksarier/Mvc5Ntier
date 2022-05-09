using BusinessLayer.CountryInfoService;
using BusinessLayer.DTO;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SoapServiceManager: CountryInfoServiceSoapTypeClient
    {
        CountryInfoServiceSoapTypeClient dn = new CountryInfoServiceSoapTypeClient();
        public List<CountryDto> List(string name)
        {
            var conutry = new List<CountryDto>();
            var deger = dn.ListOfCountryNamesByCode().Where(x => x.sName == name).SingleOrDefault();
            var Iso = deger.sISOCode;

            conutry.Add(
                    new CountryDto
                    {
                        CountryName = deger.sName,
                        CountryCa = deger.sISOCode,
                        Currency = dn.CountryCurrency(Iso).sISOCode + "(" + dn.CountryCurrency(Iso).sName + ")",
                        Capital = dn.CapitalCity(Iso),
                        
        });
    
            
            return conutry;
        }

    }
}
