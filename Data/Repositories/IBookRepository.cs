using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{
        public interface IBookRepository
        {
            IEnumerable<Book> GetAll();
            Book GetById(int bookId);
            void Add(Book book);
            void Update(Book book);
            void Delete(int bookId);
            IEnumerable<Book> Search(string keyword);
        }
    }
