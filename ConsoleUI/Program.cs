using Business.Abstract;
using Business.Utilities;
using Entity.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICustomerService customerService = NinjectInstanceFactory.GetInstance<ICustomerService>();
            //new CustomerManager(
            //new EfCustomerDal(), new KpsServiceAdapter()
            //);

            customerService.Add(new Customer());
        }
    }
}
