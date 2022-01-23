using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SQL_SYSTEM.Data;
using WPF_SQL_SYSTEM.Models;

namespace WPF_SQL_SYSTEM.Services
{

    internal interface ICustomerService
    {
        bool CreateCustomer(string firstname, string lastname, string email, string phonenumber, string streetaddress, string postalnumber, string city, string country);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
    }


    internal class CustomerService : ICustomerService
    {
        private readonly SqlContext _context = new();

        public bool CreateCustomer(string firstname, string lastname, string email, string phonenumber, string streetaddress, string postalnumber, string city, string country)
        {
            var customer = _context.Customers.Where(x => x.Email == email).FirstOrDefault();

            if (customer == null)
            {
                _context.Customers.Add(new Customer
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    PhoneNumber = phonenumber,
                    Address = new Address
                    {
                        StreetName = streetaddress,
                        PostalCode = postalnumber,
                        City = city,
                        Country = country
                    }
                });

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(x => x.Address);
        }

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.Where(x => x.Id == id).FirstOrDefault();

            return customer;
        }
    }
}
