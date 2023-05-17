using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsCurso.Domain.Commands.CreatePerson
{
    public class CreatePersonCommand
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
