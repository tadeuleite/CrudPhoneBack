namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhone
    {
        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }
    }

    public class PersonPhoneResponseDto
    {
        public int BusinessEntityID { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public string PersonName { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneType { get; set; }
    }
}
