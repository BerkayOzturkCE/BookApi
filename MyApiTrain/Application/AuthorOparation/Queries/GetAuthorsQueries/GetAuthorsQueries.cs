using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.AuthorOparation.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext=dbContext;
            _mapper=mapper;
        }

        public List<AuthorsViewModel> Handle(){

            var AuthorsList=_dbcontext.Authors.OrderBy(x=>x.id).ToList();
            
            List<AuthorsViewModel> vm= _mapper.Map<List<AuthorsViewModel>>(AuthorsList);
            
            return vm;

        }
    }

    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
    }

}