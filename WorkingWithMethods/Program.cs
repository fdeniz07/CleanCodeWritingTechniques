using System;

namespace WorkingWithMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
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

    class CustomerManager
    {
        //public void Add(string firstName, string lastName,string identityNumber,int cityId=1) -->Code Smell
        public void Add(Customer customer)
        {
            Console.WriteLine("Added");
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public int CityId { get; set; }

        #region Code Smell - Getter Setter must be managed by Central Validation System in this scenario

        /*
        public int _cityId;
        public int CityId
        {
            get
            {
                return _cityId;
            }
            set
            {
                if (value==0)
                {
                    throw new Exception("City Id is missing");
                }
            }
        }
        */
        #endregion

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
    }
}
