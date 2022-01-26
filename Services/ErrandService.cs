using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SQL_SYSTEM.Data;
using WPF_SQL_SYSTEM.Models;

namespace WPF_SQL_SYSTEM.Services
{
    internal interface IErrandService
    {
        bool CreateErrand(int customerid, string errandtitle, string erranddescription);
        IEnumerable<CustomerErrand> GetAllErrands();
    }

    internal class ErrandService : IErrandService
    {

        private readonly SqlContext _context = new();

        public bool CreateErrand(int customerid, string errandtitle, string erranddescription)
        {

            var customer = _context.Customers.Where(x => x.Id == customerid).FirstOrDefault();


            if (customer != null)
            {
                _context.CustomerErrands.Add(new CustomerErrand
                {
                    CustomerId = customerid,
                    ErrandTitle = errandtitle,
                    ErrandDescription = erranddescription,
                    ErrandCreatedTime = DateTime.Now,
                    ErrandChangedTime = DateTime.Now
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<CustomerErrand> GetAllErrands()
        {
            return _context.CustomerErrands;
        }

    }
}
