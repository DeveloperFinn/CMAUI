using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI
{

    [Table("book")]
    public class Book
    {
        [Key]
        [Column("book_id")]
        public int BookId { get; set; }
        [Column("book_title")]
        public string Title { get; set; }
        [Column("book_description")]
        public string Description { get; set; }
        [Column("book_author")]
        public string Author { get; set; }
        [Column("book_pages")]
        public int Pages { get; set; }
    }
}
