using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{
    

    
        public class ReaderRepository : IReaderRepository
        {
            private readonly AppDbContext _context;

            public ReaderRepository(AppDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Reader> GetAll()
            {
                return _context.Readers.ToList();
            }

            public Reader GetById(int readerId)
            {
                return _context.Readers.Find(readerId);
            }

            public void Add(Reader reader)
            {
                _context.Readers.Add(reader);
                _context.SaveChanges();
            }

            public void Update(Reader reader)
            {
                _context.Readers.Update(reader);
                _context.SaveChanges();
            }

            public void Delete(int readerId)
            {
                var reader = _context.Readers.Find(readerId);
                if (reader != null)
                {
                    _context.Readers.Remove(reader);
                    _context.SaveChanges();
                }
            }

            public IEnumerable<Reader> Search(string keyword)
            {
                return _context.Readers
                    .Where(r => r.FullName.Contains(keyword) || r.IDCardNumber.Contains(keyword) || r.ContactInfo.Contains(keyword))
                    .ToList();
            }
        }
    }


