using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.GenreOparation.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly BookStoreDbContext _dbcontext;
        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {

            var genre = _dbcontext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();

            if (genre is null)
            {
                throw new InvalidOperationException("Kitap türü Bulunamadı.");
            }

            _dbcontext.Genres.Remove(genre);
            _dbcontext.SaveChanges();
            return;


        }
    }



}