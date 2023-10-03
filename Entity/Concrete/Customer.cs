namespace Entity.Concrete
{
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
}