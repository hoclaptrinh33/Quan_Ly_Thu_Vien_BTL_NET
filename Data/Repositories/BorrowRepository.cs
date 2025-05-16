using System;
using System.Collections.Generic;
using System.Linq;
using Quan_Ly_Thu_Vien_BTL_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{
    public class BorrowRepository : IBorrowRepository
    {
        private readonly AppDbContext _context;

        public BorrowRepository(AppDbContext context)
        {
            _context = context;
        }

        

public List<Borrow> GetAll()
{
    return _context.Borrow
        .Include(b => b.Book)
        .Include(b => b.Reader)
        .OrderByDescending(b => b.BorrowDate)
        .ToList();
}


        public Borrow GetById(int id)
        {
            return _context.Borrow.Find(id);
        }

        public void Add(Borrow borrow)
        {
            _context.Borrow.Add(borrow);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var borrow = GetById(id);
            if (borrow != null)
            {
                _context.Borrow.Remove(borrow);
                _context.SaveChanges();
            }
        }

        public void MarkAsReturned(int borrowId)
        {
            var borrow = GetById(borrowId);
            if (borrow != null && borrow.ReturnDate == null)
            {
                borrow.ReturnDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public List<Borrow> GetBorrowsByReaderId(int readerId)
        {
            return _context.Borrow
                .Where(b => b.ReaderId == readerId)
                .ToList();
        }

        public List<Borrow> GetBorrowsByBookId(int bookId)
        {
            return _context.Borrow
                .Where(b => b.BookId == bookId)
                .ToList();
        }

        public List<Borrow> Search(string keyword)
        {
            return _context.Borrow
                .Where(b => b.Reader.FullName.Contains(keyword) || b.Book.Title.Contains(keyword))
                .ToList();
        }

        public void Update(Borrow borrow)
        {
            var existingBorrow = GetById(borrow.BorrowId);
            if (existingBorrow != null)
            {
                existingBorrow.BookId = borrow.BookId;
                existingBorrow.ReaderId = borrow.ReaderId;
                existingBorrow.BorrowDate = borrow.BorrowDate;
                existingBorrow.DueDate = borrow.DueDate;
                existingBorrow.ReturnDate = borrow.ReturnDate;
                existingBorrow.IsRenewed = borrow.IsRenewed;
                existingBorrow.FineAmount = borrow.FineAmount;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Phiếu mượn không tồn tại.");
            }
        }
    }
}
