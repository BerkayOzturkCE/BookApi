using AutoMapper;
using  MyApiTrain.BookOparation.GetBookById;
using  static MyApiTrain.BookOparation.CreateBook.CreateBookCommand;
using  MyApiTrain.BookOparation.GetBooks;

namespace MyApiTrain.Common
{
    public class MappingProfile: Profile{
        public MappingProfile(){
                CreateMap<CreateBookModel,Book>();
                CreateMap<Book, BookViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
                CreateMap<Book, BooksViewModel>().ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }
    }
}