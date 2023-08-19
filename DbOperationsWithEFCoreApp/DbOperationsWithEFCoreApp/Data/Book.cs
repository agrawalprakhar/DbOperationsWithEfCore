using System.ComponentModel.DataAnnotations;

namespace DbOperationsWithEFCoreApp.Data
{
   
    public class Books
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Range(0.01, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public int Price { get; set; }
        public string Genre { get; set; }
    }

}
