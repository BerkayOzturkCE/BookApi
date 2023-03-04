using Microsoft.AspNetCore.Mvc;
using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.AuthorOparation.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _dbcontext;
        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {

            var author = _dbcontext.Authors.Where(x => x.id == AuthorId).SingleOrDefault();

            if (author is null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı.");
            }

            if (_dbcontext.Books.Any(x => x.Author == author))
            {
                
                throw new InvalidOperationException("Yazara ait kitaplar Bulunmaktadır. Önce Kitapları siliniz.");

            }

            _dbcontext.Authors.Remove(author);
            _dbcontext.SaveChanges();
            return;


        }
    }



}