using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thu_Vien_BTL_NET.Models
{
    public class Reader
    {

            [Key]
            public int ReaderId { get; set; }

            [Required]
            [MaxLength(255)]
            public string FullName { get; set; }

            public DateTime DateOfBirth { get; set; }

            [MaxLength(20)]
            public string IDCardNumber { get; set; }

            [MaxLength(500)]
            public string Address { get; set; }

            [MaxLength(100)]
            public string ContactInfo { get; set; }

            public  ICollection<Borrow> BorrowRecords { get; set; }


    }
    }


