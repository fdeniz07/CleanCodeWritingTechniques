using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.NHibernate
{
    public class NhCustomerDal : ICustomerDal
    {
        public void Add(Customer customer)
        {
            Console.WriteLine("Added via NHibernate to Database");
        }

        public bool CustomerExists(Customer customer)
        {
            return true;
        }
    }
}
