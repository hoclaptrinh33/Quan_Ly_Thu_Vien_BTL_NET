using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{



        public class BookRepository : IBookRepository
        {
            private readonly AppDbContext _context;

            public BookRepository(AppDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Book> GetAll()
            {
                return _context.Books.Include(b => b.Category).ToList();
            }

            public Book GetById(int bookId)
            {
                return _context.Books.Include(b => b.Category).FirstOrDefault(b => b.BookId == bookId);
            }

            public void Add(Book book)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }

            public void Update(Book book)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
            }

            public void Delete(int bookId)
            {
                var book = _context.Books.Find(bookId);
                if (book != null)
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }
            }

            public IEnumerable<Book> Search(string keyword)
            {
                return _context.Books
                    .Include(b => b.Category)
                    .Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword) || b.Publisher.Contains(keyword))
                    .ToList();
            }
        }
    }


