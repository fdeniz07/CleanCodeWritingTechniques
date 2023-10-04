using Entity;

namespace DataAccess
{
    public interface IProductDal
    {
        List<Product> GetAll();
    }
}