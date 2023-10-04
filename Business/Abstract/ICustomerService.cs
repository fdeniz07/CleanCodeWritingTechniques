using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        void Add(Customer customer);
        bool CustomerExists(Customer customer);
    }
}
