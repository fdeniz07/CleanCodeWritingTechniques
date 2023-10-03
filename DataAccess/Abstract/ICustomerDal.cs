using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDal
    {
        /// <summary>
        /// Customer adding operation
        /// </summary>
        /// <param name="customer"></param>
        void Add(Customer customer);
        bool CustomerExists(Customer customer);
    }
}
