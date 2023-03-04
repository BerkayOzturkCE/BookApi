
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.GenreOparation.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        public int GenreId { get; set; }

        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetGenreByIdQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public GenreViewModel Handle()
        {

            var genre = _dbcontext.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);

            if (genre is null)
            {
                throw new InvalidOperationException("Tür Bulunamadı.");
            }

            GenreViewModel returnObj = _mapper.Map<GenreViewModel>(genre);
            return returnObj;

        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}