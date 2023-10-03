using FluentValidation;
using System;

namespace WorkingWithMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal(), new KpsServiceAdapter());
            //customerManager.Add("Fatih","Deniz","111111");
            //customerManager.Add("John","Rambo","222222");
            //customerManager.Add("Marie","Lee","333333",1);
            //customerManager.Add("Gul","Bahar","444444");
            //customerManager.Add("Ozlem","Sevgi","555555",2);
            customerManager.Add(new Customer
            {
                FirstName = "Fatih",
                LastName = "Deniz",
                IdentityNumber = "11111111"
            });

            customerManager.Add(new Customer
            {
                FirstName = "John",
                LastName = "Rambo",
                IdentityNumber = "222222",
                CityId = 2
            });

            customerManager.Add(new Customer
            {
                FirstName = "Marie",
                LastName = "Lee",
                IdentityNumber = "333333"
            });
        }
    }



    // There should be no bare class!
    /*
    public class CustomerDal
    {
        private DatabaseType _databaseType;

        public CustomerDal(DatabaseType databaseType)
        {
            _databaseType = databaseType;
        }

        public void Add(Customer customer)
        {
            if (_databaseType==DatabaseType.Oracle)
            {
                Console.WriteLine("Added via NHibernate to Database");
            }
            else
            {
                Console.WriteLine("Added via EntityFramework to Database");
            }
        }

        public bool CustomerExists(Customer customer)
        {
            return true;
        }
    }
    */


}