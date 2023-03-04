using AutoMapper;
using MyApiTrain.Application.AuthorOparation.Queries.GetAuthorById;
using MyApiTrain.Application.AuthorOparation.Queries.GetAuthors;
using MyApiTrain.Application.BookOparation.Queries.GetBookById;
using MyApiTrain.Application.BookOparation.Queries.GetBooks;
using MyApiTrain.Application.GenreOparation.Queries.GetGenreById;
using MyApiTrain.Application.GenreOparation.Queries.GetGenres;
using MyApiTrain.Entities;
using static MyApiTrain.Application.AuthorOparation.Commands.CreateAuthor.CreateAuthorCommand;
using static MyApiTrain.Application.BookOparation.Commands.CreateBook.CreateBookCommand;
using static MyApiTrain.Application.GenreOparation.Commands.CreateGenre.CreateGenreCommand;

namespace MyApiTrain.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+ " " +src.Author.Surname));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+ " " +src.Author.Surname));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<CreateGenreModel, Genre>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author,AuthorsViewModel>();
            CreateMap<Author,AuthorViewModel>();






        }
    }
}