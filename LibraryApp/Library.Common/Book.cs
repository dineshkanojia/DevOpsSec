using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        [Required(ErrorMessage ="Book Name Required")]
        [DisplayName("Book Name")]
        public string BookName { get; set; }
        
        [Required(ErrorMessage = "Publisher Name Required")]
        [DisplayName("Publisher Name")]
        public string PublisherName { get; set; }
        
        [Required(ErrorMessage = "Published Date Required")]
        [DisplayName("Published Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }
        
        [Required(ErrorMessage = "Version Required")]
        public string Version { get; set; }
        
        [Required(ErrorMessage = "Author Name Required")]
        [DisplayName("Author Name")]
        public string AutherName { get; set; }

        [Required(ErrorMessage = "Book Price Required")]
        [DisplayName("Book Price")]
        public int BookPrice { get; set; }
        
        [Required(ErrorMessage = "Add quantity Required")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

       
        [DisplayName("File Name")]
        public string FileName { get; set; }

      
        [DisplayName("File")]
                public byte[] FileContents { get; set; }
        [DisplayName("File Extension")]
        public string FileExtention { get; set; }
        public bool? IsDelete { get; set; }
    }
}
