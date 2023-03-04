using MyApiTrain.DbOparations;

namespace MyApiTrain.Application.GenreOparation.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdatedGenreModel UpdatedGenre { get; set; }
        public int GenreId { get; set; }

        private readonly BookStoreDbContext _context;
        public UpdateGenreCommand(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Handle()
        {

            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("tür Bulunamadı.");
            }

            if (_context.Genres.Any(x => x.Name.ToLower() == UpdatedGenre.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Aynı isimde bir kitap türü zaten mevcut.");
            }
            genre.Name = UpdatedGenre.Name.Trim() != default ? UpdatedGenre.Name : genre.Name;
            genre.IsActive = UpdatedGenre.IsActive;

            _context.SaveChanges();
        }


        public class UpdatedGenreModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; } = true;

        }
    }


}