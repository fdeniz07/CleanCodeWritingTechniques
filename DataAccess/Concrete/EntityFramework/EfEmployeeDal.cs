using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : IEmployeeDal
    {
        public List<Employee> GetAll()
        {
            return new List<Employee>{
                new Employee
                {
                    Id=1,
                    FirstName = "Max",
                    LastName = "Mustermann",
                    IdentityNumber = "12345",
                    Salary = 4000,
                    YearOfBirth = 1988
                 },
                new Employee
                {
                    Id=2,
                    FirstName = "Jane",
                    LastName = "Fox",
                    IdentityNumber = "67890",
                    Salary = 3000,
                    YearOfBirth = 2000
                }
            };
        }
    }
}
