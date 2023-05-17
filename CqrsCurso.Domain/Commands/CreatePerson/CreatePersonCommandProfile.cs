using AutoMapper;
using CqrsCurso.Domain.Domain;
using CqrsCurso.Domain.Helpers;

namespace CqrsCurso.Domain.Commands.CreatePerson
{
    public class CreatePersonCommandProfile : Profile
    {
        public CreatePersonCommandProfile()
        {
            CreateMap<CreatePersonCommand, Person>()
                .ForMember(fieldOutput => fieldOutput.CPF, option => option
                    .MapFrom(input => input.CPF.RemoveMaskCpf()))
                .ForMember(fieldOutput => fieldOutput.Name, option => option
                    .MapFrom(input => input.Name.ToUpper()))
                .ForMember(fieldOutput => fieldOutput.Email, option => option
                    .MapFrom(input => input.Email.ToUpper()));
        }
    }
}
