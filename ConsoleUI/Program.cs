using Business;
using Business.Abstract;
using Business.Utilities;
using Entity.Concrete;

namespace ConsoleUI
{
    //intentional programming / niyet güdümlü programlama
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerDemo();
           
            //EmployeeDemo();

            IProductService productService = NinjectInstanceFactory.GetInstance<IProductService>();
            var result = productService.GetAll();

            foreach (var product in result)
            {
                Console.WriteLine(product.Name);
            }
            
            Console.ReadLine();
        }

        private static void EmployeeDemo()
        {
            IEmployeeService employeeService = NinjectInstanceFactory.GetInstance<IEmployeeService>();
            var result = employeeService.GetAll();

            foreach (var employee in result)
            {
                Console.WriteLine(employee.FirstName);
            }
        }

        private static void CustomerDemo()
        {
            ICustomerService customerService = NinjectInstanceFactory.GetInstance<ICustomerService>();
            //new CustomerManager(new EfCustomerDal(), new KpsServiceAdapter());

            customerService.Add(new Customer());
        }
    }
}
