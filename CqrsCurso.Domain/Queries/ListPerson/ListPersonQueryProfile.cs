using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CqrsCurso.Domain.Domain;
using CqrsCurso.Domain.Helpers;

namespace CqrsCurso.Domain.Queries.ListPerson
{
    public class ListPersonQueryProfile : Profile
    {
        public ListPersonQueryProfile()
        {
            CreateMap<Person, ListPersonQueryResponse>()
                .ForMember(fieldOutPut => fieldOutPut.CPF, option => option
                .MapFrom(input => input.CPF.FormatCpf()));
        }
    }
}
