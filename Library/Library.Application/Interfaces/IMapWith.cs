using AutoMapper;

namespace Library.Application.Interfaces
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
         profile.CreateMap(typeof(T), GetType());
    }
}
