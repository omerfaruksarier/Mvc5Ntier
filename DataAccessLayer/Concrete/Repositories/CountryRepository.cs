using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CountryRepository : ICountryDal
    {
        Context cnt = new Context();

        DbSet<Country> _object;
        public void Delete(Country c)
        {
            _object.Remove(c);
            cnt.SaveChanges();
        }

        public void Insert(Country c)
        {
            _object.Add(c);
            cnt.SaveChanges();
        }

        public List<Country> List()
        {
            return _object.ToList();
        }

        public List<Country> List(Expression<Func<Country, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Country c)
        {
           cnt.SaveChanges();
        }
    }
}
