using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rira.BackEnd.SeniorTask.Dtos
{
    public class EditPersonDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string NationalCode { get; set; }

        public string BirthDay { get; set; }
    }
}
