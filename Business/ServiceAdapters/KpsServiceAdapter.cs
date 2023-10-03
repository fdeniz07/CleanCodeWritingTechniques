using Business.Abstract;
using Entity.Concrete;

namespace Business.ServiceAdapters
{
    //Don't touch this Code
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

}
