using Business.Abstract;
using Business.Utilities;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
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

        public bool CustomerExists(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
