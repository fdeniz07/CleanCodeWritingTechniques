using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer customer)
        {
            Console.WriteLine("Added via EntityFramework to Database");
        }

        public bool CustomerExists(Customer customer)
        {
            return true;
        }
    }
}
