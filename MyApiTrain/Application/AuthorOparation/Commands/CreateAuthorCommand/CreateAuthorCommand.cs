using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;
using MyApiTrain.Entities;

namespace MyApiTrain.Application.AuthorOparation.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel model {get;set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        { 

            var author = _dbcontext.Authors.SingleOrDefault(x => x.Name == model.Name && x.Surname == model.Surname);
            if (author is not null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }
            author= _mapper.Map<Author>(model); 
       
            _dbcontext.Authors.Add(author);
            _dbcontext.SaveChanges();
        }


        public class CreateAuthorModel
        {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    
        }
    }


}