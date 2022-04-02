using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;

namespace Library.Application.CQRS.Querys.PersonQuerys.GetAllTakenBooksByPersonId
{
    public class AuthorVm:IMapWith<Author>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorVm>()
                .ForMember(dto => dto.Id,
                opt => opt.MapFrom(vm => vm.Id))
                .ForMember(dto => dto.FirstName,
                opt => opt.MapFrom(vm => vm.FirstName))
                .ForMember(dto => dto.LastName,
                opt => opt.MapFrom(vm => vm.LastName))
                .ForMember(dto => dto.MiddleName,
                opt => opt.MapFrom(vm => vm.MiddleName));
        }
    }
}