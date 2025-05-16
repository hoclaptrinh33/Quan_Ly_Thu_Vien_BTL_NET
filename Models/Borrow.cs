using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thu_Vien_BTL_NET.Models
{
    public class Borrow
    {

            [Key]
            public int BorrowId { get; set; }

            [ForeignKey("Reader")]
            public int ReaderId { get; set; }
            public Reader Reader { get; set; }

            [ForeignKey("Book")]
            public int BookId { get; set; }
            public Book Book { get; set; }

            public DateTime BorrowDate { get; set; }

            public DateTime DueDate { get; set; }

            public DateTime? ReturnDate { get; set; }

            public bool IsRenewed { get; set; }

            public decimal FineAmount { get; set; }
        }
    }



