using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thu_Vien_BTL_NET.Models
{
    public class Book
    {

            [Key]
            public int BookId { get; set; }

            [Required]
            [MaxLength(255)]
            public string Title { get; set; }

            [MaxLength(255)]
            public string Author { get; set; }

            [MaxLength(255)]
            public string Publisher { get; set; }

            [ForeignKey("Category")]
            public int CategoryId { get; set; }
            public Category Category { get; set; }


            [MaxLength(100)]
            public string Location { get; set; }

            [Required]
            public int Quantity { get; set; } 


            public ICollection<Borrow> BorrowRecords { get; set; }
        }
    }



