using AutoMapper;
using Library.Application.Interfaces;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.CQRS.Querys.HumanQuerys.GetHumanList
{
    public class HumanLookupDto:IMapWith<Human>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Book> Books { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Human, HumanLookupDto>()
                .ForMember(humanDto => humanDto.Id,
                opt => opt.MapFrom(human => human.Id))
                .ForMember(humanDto => humanDto.Name,
                opt => opt.MapFrom(human => human.Name))
                .ForMember(humanDto => humanDto.Birthday,
                opt => opt.MapFrom(human => human.Birthday))
                .ForMember(humanDto => humanDto.Patronymic,
                opt => opt.MapFrom(human => human.Patronymic))
                .ForMember(humanDto => humanDto.Surname,
                opt => opt.MapFrom(human => human.Surname))
                .ForMember(humanDto => humanDto.Books,
                opt => opt.MapFrom(human => human.Books));
        }
    }
}
