using Entity;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public List<Product> GetAll()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Laptop"
                }
            };
        }
    }
}
