namespace Rira.BackEnd.SeniorTask.BlazorWebAssembly.Models
{
    public class PersonViewModel
    {
        public long Id { get; set; }  
        public string Name { get; set; } = "";
        public string FamilyName { get; set; } = "";
        public string NationalCode { get; set; } = "";
        public string BirthDay { get; set; } = "";

        public PersonViewModel Clone()
        {
            return new PersonViewModel()
            {
                Id = Id,
                Name = Name,
                FamilyName = FamilyName,
                NationalCode = NationalCode,
                BirthDay = BirthDay,
            };
        }
    }
}
