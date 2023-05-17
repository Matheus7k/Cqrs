using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CqrsCurso.Domain.Domain;
using CqrsCurso.Domain.Helpers;

namespace CqrsCurso.Domain.Queries.GetPerson
{
    public class GetPersonQueryProfile : Profile
    {
        public GetPersonQueryProfile()
        {
            CreateMap<Person, GetPersonQueryResponse>()
            .ForMember(fieldOutput => fieldOutput.Cpf, option => option
                .MapFrom(input => input.CPF.FormatCpf()));
        }
    }
}
