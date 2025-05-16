using System;
using System.Collections.Generic;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{
    public interface IBorrowRepository
    {
        List<Borrow> GetAll();
        Borrow GetById(int id);
        void Add(Borrow borrow);
        void Delete(int id);
        void MarkAsReturned(int borrowId);
        List<Borrow> GetBorrowsByReaderId(int readerId);
        List<Borrow> GetBorrowsByBookId(int bookId);
        List<Borrow> Search(string keyword);
        void Update(Borrow borrow);
    }
}
