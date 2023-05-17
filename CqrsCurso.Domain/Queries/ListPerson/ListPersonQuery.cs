using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsCurso.Domain.Queries.ListPerson
{
    public class ListPersonQuery
    {
        public ListPersonQuery(string? name, string? cpf)
        {
            Name = name;
            CPF = cpf;
        }

        public string? Name { get; set; }
        public string? CPF { get; set; }
    }
}
