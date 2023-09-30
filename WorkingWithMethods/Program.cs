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

    public class CustomerManager
    {
        private ICustomerDal _customerDal;
        private IPersonService _personService;

        public CustomerManager(ICustomerDal customerDal, IPersonService personService)
        {
            _customerDal = customerDal;
            _personService = personService;
        }


        //public void Add(string firstName, string lastName,string identityNumber,int cityId=1) -->Code Smell
        //This code adds Customer
        public void Add(Customer customer)
        {
            #region Code Smell - Validation codes and business codes cannot be written inside each other.

            //Code Smell
            // Is kodlari ile dogrulama kodlari ic ice yazilmaz
            /*
             if (!String.IsNullOrEmpty(customer.FirstName) &&
                 !String.IsNullOrEmpty(customer.LastName) &&
                 !String.IsNullOrEmpty(customer.IdentityNumber) )
             {
                 Console.WriteLine("Added");
             }
             */

            //tecnical debt - teknik borclanma
            /*
           if (String.IsNullOrEmpty(customer.FirstName) ||
               String.IsNullOrEmpty(customer.LastName) ||
               String.IsNullOrEmpty(customer.IdentityNumber) )
           {
               throw new Exception("Validation error");
           }
            Console.WriteLine("Added");
           */

            #endregion

            #region Validations or business rules should be broken down into smaller pieces

            // Validate(customer);

            #endregion

            //Validation Rules with Methods
            //ValidateFirstNameIfEmpty(customer);
            //ValidateLastNameIfEmpty(customer);
            //ValidateIdentityNumberIfEmpty(customer);

            //Validation Rules with FluentValidation
            //validation should not be checked here but should be refactored instead
            //CustomerValidator customerValidator = new CustomerValidator();
            //var result = customerValidator.Validate(customer);
            //if (result.Errors.Count>0)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            Utility.Validate(new CustomerValidator(), customer);

            CheckPersonExists(customer);

            //Business Rules
            //Check Users on the Database
            CheckCustomerExists(customer);

            //CustomerDal customerDal = new CustomerDal(DatabaseType.Oracle);
            //if (!customerDal.CustomerExists(customer))
            //{
            //    customerDal.Add(customer);
            //}

            // customerDal.Add(customer);
            _customerDal.Add(customer);
        }


        public void AddByOtherBusiness(Customer customer)
        {
            //Validation Rules with Methods
            ValidateFirstNameIfEmpty(customer);
            ValidateLastNameIfEmpty(customer);
            ValidateFirstNameLength(customer);

            //Business Rules
            CheckCustomerExists(customer);
            /*
             CustomerDal customerDal = new CustomerDal();
                 if (!customerDal.CustomerExists(customer))
                 {
                   customerDal.Add(customer);
                 }
            */
            // customerDal.Add(customer);
            _customerDal.Add(customer);
        }

        #region Validations or business rules should be broken down into smaller pieces

        /*
              private void Validate(Customer customer)
             {
                 if (String.IsNullOrEmpty(customer.FirstName)||
                     String.IsNullOrEmpty(customer.LastName)||
                     String.IsNullOrEmpty(customer.IdentityNumber))
                 {
                     throw new Exception("Validation error");
                 }
             }
         */

        #endregion


        private void CheckCustomerExists(Customer customer)
        {
            //CustomerDal customerDal = new CustomerDal(DatabaseType.Oracle);
            if (_customerDal.CustomerExists(customer))
            {
                throw new Exception("Customer is already exist");
            }
        }

        /// <summary>
        /// We check the accuracy of personal information
        /// </summary>
        /// <param name="person">Person Information</param>
        /// <exception cref="System.Exception">Person information is invalid</exception>
        private void CheckPersonExists(Person person)
        {
            if (!_personService.checkPerson(person))
            {
                throw new Exception("Person information is invalid");
            }
        }

        private void ValidateFirstNameIfEmpty(Customer customer)
        {
            if (String.IsNullOrEmpty(customer.FirstName))
            {
                throw new Exception("Validation error");
            }
        }

        private void ValidateLastNameIfEmpty(Customer customer)
        {
            if (String.IsNullOrEmpty(customer.LastName))
            {
                throw new Exception("Validation error");
            }
        }

        private void ValidateIdentityNumberIfEmpty(Customer customer)
        {
            if (String.IsNullOrEmpty(customer.IdentityNumber))
            {
                throw new Exception("Validation error");
            }
        }

        private void ValidateFirstNameLength(Customer customer)
        {
            if (customer.FirstName.Length < 2)
            {
                throw new Exception("Validation error");
            }
        }
    }


    public interface ICustomerDal
    {
        /// <summary>
        /// Customer adding operation
        /// </summary>
        /// <param name="customer"></param>
        void Add(Customer customer);
        bool CustomerExists(Customer customer);
    }


    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer customer)
        {
            Console.WriteLine("Added via EntityFramework to Database");
        }

        public bool CustomerExists(Customer customer)
        {
            return true;
        }
    }

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

    public class Customer : Person
    {
        //public int Id { get; set; }
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

        // [Required] --> Data annotation should not be used in the entity layer. It is against SOLID principles.
        // [MinLength(2)]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string IdentityNumber { get; set; }
    }

    // Enum Types should be checked!
    //public enum DatabaseType
    //{
    //    Oracle,
    //    SqlServer
    //}

    // Outsource service code
    public class KpsService
    {
        public bool CheckPerson(long iSN, string firstName, string lastName, int year)
        {
            //....
            return true;
        }
    }

    public class KpsServiceAdapter : IPersonService
    {
        public bool checkPerson(Person person)
        {
            KpsService kpsService = new KpsService();
            return kpsService.CheckPerson(Convert.ToInt64(person.IdentityNumber), person.FirstName, person.LastName,
                person.YearOfBirth);
        }
    }

    public interface IPersonService
    {
        bool checkPerson(Person person);
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public int YearOfBirth { get; set; }
    }
}