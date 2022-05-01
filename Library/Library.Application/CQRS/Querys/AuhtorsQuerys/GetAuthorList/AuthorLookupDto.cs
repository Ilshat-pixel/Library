using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys
{
    public class AuthorLookupDto:IMapWith<Author>
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorLookupDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(a => a.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(a => a.MiddleName + a.FirstName + a.LastName));
        } 
    }
}
