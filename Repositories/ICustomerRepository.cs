using INV_APPLICATION.Models;

namespace INV_APPLICATION.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetAll();
        void Add(Customer customer);
        void Update( Customer customer);
        void Delete(Customer customer);
    }
}
