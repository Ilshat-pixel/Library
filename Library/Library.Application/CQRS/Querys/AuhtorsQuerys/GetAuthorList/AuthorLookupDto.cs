using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.AuhtorsQuerys.GetAuthorList
{
    public class GetAuthorListQueryDto:IMapWith<Author>
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, GetAuthorListQueryDto>()
                .ForMember(x => x.Id,
                opt => opt.MapFrom(a => a.Id))
                .ForMember(x => x.Name,
                opt => opt.MapFrom(a => a.MiddleName + a.FirstName + a.LastName));
        } 
    }
}
