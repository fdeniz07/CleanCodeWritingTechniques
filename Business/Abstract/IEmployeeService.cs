using Entity.Concrete;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
    }
}
