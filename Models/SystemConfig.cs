using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thu_Vien_BTL_NET.Models
{

        public class SystemConfig
        {
            [Key]
            public int ConfigId { get; set; }

            public int MaxBorrowDays { get; set; }

            public int MaxBooksPerReader { get; set; }

            public decimal FinePerDay { get; set; }
        }
    }

