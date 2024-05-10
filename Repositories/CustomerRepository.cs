using INV_APPLICATION.Data;
using INV_APPLICATION.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace INV_APPLICATION.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _Context;

        public CustomerRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        public void Add(Customer customer)
        {
            _Context.TbCustomer.Add(customer);
            _Context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _Context.TbCustomer.Remove(customer);
            _Context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _Context.TbCustomer.Include(p => p.Zone).ToList();
        }

        public Customer GetById(int id)
        {
            return _Context.TbCustomer
                           .Include(c => c.Zone)
                           .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = _Context.TbCustomer.FirstOrDefault(x => x.Id == customer.Id)!;
            existingCustomer.FullName = customer.FullName;
            existingCustomer.CellPhone = customer.CellPhone;
            existingCustomer.Description = customer.Description;
            existingCustomer.Email = customer.Email;
            existingCustomer.Zone = customer.Zone;
            existingCustomer.NIF = customer.NIF;

            _Context.SaveChanges();
        }


    }
}

