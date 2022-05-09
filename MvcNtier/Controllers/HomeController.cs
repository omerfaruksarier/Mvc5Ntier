using BusinessLayer.Concrete;
using BusinessLayer.CountryInfoService;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;
using System.Data.Entity;

namespace MvcNtier.Controllers
{
    public class HomeController : Controller
    {
        CountryManager cm = new CountryManager(new EfCountryDal());

        Context db = new Context();
        SoapServiceManager ssm = new SoapServiceManager();

        [HttpGet]
        public ActionResult Index()
        {
            List<SelectListItem> country = new List<SelectListItem>();

            foreach (var item in ssm.ListOfCountryNamesByCode())
            {

                country.Add(new SelectListItem
                {
                    Text = item.sName,

                });
            }
            //Dinamik bir yapı oluşturup ülkeler list mizi view mize göndereceğiz
            //bunun için viewbag kullanıyorum
            ViewBag.country = country;

            return View();
        }

        public PartialViewResult GetCountryListPartial(string Name)
        {
            if (Name != null)
            {
                ViewBag.CountryName = Name;

                var deger = ssm.List(Name);

                return PartialView(deger);
            }
            return PartialView();
        }

        [HttpPost]
        public string AddCountryAj(string country, string ca, string capital, string currency)
        {
            try
            {
                var deger = db.Countries.Where(x => x.CountryName == country).FirstOrDefault();
                if (deger != null)
                {
                    return "dolu";
                }
                else
                {
                    Country c = new Country();

                    c.Capital = capital;
                    c.CountryCa = ca;
                    c.CountryCurrency = currency;
                    c.CountryName = country;


                    CountryValidator countryValidator = new CountryValidator();

                    ValidationResult results = countryValidator.Validate(c);

                    if (results.IsValid)
                    {
                        cm.CountryAdd(c);
                        return "true";
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                        return "hata";

                    }
                }


            }
            catch (Exception)
            {

                return "hata";
            }
        }

    }
}

