using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thu_Vien_BTL_NET.Models
{
    
        public class Category
        {
            [Key]
            public int CategoryId { get; set; }

            [Required]
            [MaxLength(100)]
            public string CategoryName { get; set; }

            public ICollection<Book> Books { get; set; }
        }
    }

