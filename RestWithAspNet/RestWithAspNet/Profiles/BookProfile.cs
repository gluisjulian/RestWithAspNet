using AutoMapper;
using RestWithAspNet.Data.DTO;
using RestWithAspNet.Model;

namespace RestWithAspNet.Profiles
{
    public class BookProfile : Profile
    {

        public BookProfile()
        {
            //De BookDTO -> para Book
            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Id, origem => origem.MapFrom(origem => origem.Id))
                .ForMember(dest => dest.Title, origem => origem.MapFrom(origem => origem.Title))
                .ForMember(dest => dest.Author, origem => origem.MapFrom(origem => origem.Author))
                .ForMember(dest => dest.Price, origem => origem.MapFrom(origem => origem.Price))
                .ForMember(dest => dest.LaunchDate, origem => origem.MapFrom(origem => origem.LaunchDate));


            //De Book -> para BookDTO
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Id, origem => origem.MapFrom(origem => origem.Id))
                .ForMember(dest => dest.Title, origem => origem.MapFrom(origem => origem.Title))
                .ForMember(dest => dest.Author, origem => origem.MapFrom(origem => origem.Author))
                .ForMember(dest => dest.Price, origem => origem.MapFrom(origem => origem.Price))
                .ForMember(dest => dest.LaunchDate, origem => origem.MapFrom(origem => origem.LaunchDate));
        }
    }
}
