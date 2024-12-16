namespace Rira.BackEnd.SeniorTask.Entity
{
    public class Person
    {
        public long Id { get; private set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string NationalCode { get; set; }

        public DateOnly BirthDay { get; set; }
    }
}
