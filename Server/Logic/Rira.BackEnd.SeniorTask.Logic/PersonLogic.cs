using Rira.BackEnd.SeniorTask.Dtos;
using Rira.BackEnd.SeniorTask.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rira.BackEnd.SeniorTask.Logic
{
    public class PersonLogic
    {
        IPersonRepository _personRepository;
        public PersonLogic(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task UpdateAsync(EditPersonDto dto)
        {
            var person = await _personRepository.GetByIdAsync(dto.Id);

            var birthDayDate = ValidateAndConvertBirthday(dto.BirthDay);

            person.Name = dto.Name;
            person.FamilyName = dto.FamilyName;
            person.NationalCode = dto.NationalCode;
            person.BirthDay = birthDayDate;

            await _personRepository.UpdateAsync(person);
        }

        public async Task CreateAsync(CreatePersonDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new Exception($"{nameof(CreatePersonDto.Name)} is required");

            if (string.IsNullOrWhiteSpace(dto.NationalCode))
                throw new Exception($"{nameof(CreatePersonDto.NationalCode)} is required");


            var birthDayDate = ValidateAndConvertBirthday(dto.BirthDay);

            await _personRepository.CreateAsync(new Entity.Person()
            {
                BirthDay = birthDayDate,
                FamilyName = dto.FamilyName,
                Name = dto.Name,
                NationalCode = dto.NationalCode
            });
        }

        private static DateOnly ValidateAndConvertBirthday(string birthDay)
        {
            DateOnly birthDayDate = DateOnly.MinValue;
            if (string.IsNullOrWhiteSpace(birthDay) == false && (DateOnly.TryParse(birthDay, out birthDayDate) == false))
                throw new Exception($"{nameof(CreatePersonDto.BirthDay)} is not valid");
            return birthDayDate;
        }

        public async Task<List<PersonDto>> GetAllAsync()
        {
            List<PersonDto> personDtos = new List<PersonDto>();
            var persons = await _personRepository.GetAllAsync();
            foreach (var person in persons)
            {
                personDtos.Add(new PersonDto()
                {
                    Id = person.Id,
                    BirthDay = person.BirthDay == DateOnly.MinValue ? "" : person.BirthDay.ToString("yyyy-MM-dd"),
                    FamilyName = person.FamilyName,
                    Name = person.Name,
                    NationalCode = person.NationalCode
                });
            }

            return personDtos;
        }

        public async Task DeleteAsync(DeletePersonDto dto)
        {
           await _personRepository.DeleteAsync(dto.Id);
        }
    }
}
