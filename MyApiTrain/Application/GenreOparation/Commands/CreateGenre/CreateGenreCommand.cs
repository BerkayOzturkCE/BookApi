using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.GenreOparation.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel model{get;set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateGenreCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        { 

            var genre = _dbcontext.Genres.SingleOrDefault(x => x.Name == model.Name);
            if (genre is not null)
            {
                throw new InvalidOperationException("Tür zaten mevcut");
            }
            genre= _mapper.Map<Genre>(model); 
       
            _dbcontext.Genres.Add(genre);
            _dbcontext.SaveChanges();
        }


        public class CreateGenreModel
        {
        public string Name { get; set; }
    
        }
    }


}