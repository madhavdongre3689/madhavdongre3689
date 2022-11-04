using System.ComponentModel.DataAnnotations;

namespace BookEntities.BusinessEntities
{
    public class BookDto
    {

        public string? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? AuthorName { get; set; }

    }
}