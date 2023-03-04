using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.GenreOparation.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {

            var genres = _dbcontext.Genres.Where(genre => genre.IsActive).OrderBy(genre=>genre.Id);

            if (genres is null)
            {
                throw new InvalidOperationException("Tür Bulunamadı.");
            }

            List<GenresViewModel> returnObj=_mapper.Map<List<GenresViewModel>>(genres); 
            return returnObj;

        }
    }

    public class GenresViewModel
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }

}