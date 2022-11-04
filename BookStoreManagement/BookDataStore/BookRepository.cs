using BookEntities.BusinessEntities;
using BookEntities.Exceptions;

namespace BookDataStore
{
    public class BookRepository : Repository<BookDto>
    {
        public BookRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public override void Create(BookDto entity)
        {
            if (entity == null)
            {
                throw new DatabaseException("Entity cannot be empty");
            }
           dbContext.Books?.Add(entity);
           dbContext.SaveChanges();
        }

        public override BookDto Read(string Id)
        {
            var entity = dbContext.Books?.Find(Id);
            if (entity == null)
            {
                throw new DatabaseException("Entity not found");
            }
            return entity;
        }

        public override void Update(BookDto entity)
        {
            if (entity == null)
            {
                throw new DatabaseException("Entity cannot be empty");
            }
            dbContext.Books?.Update(entity);
            dbContext.SaveChanges();
        }

        public override IEnumerable<BookDto> GetAllBooks()
        {
            var bookList = dbContext?.Books?.ToList();
            return bookList;
        }
    }
}