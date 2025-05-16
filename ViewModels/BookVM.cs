using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private readonly IBookRepository _bookRepository;

        public BindingList<Book> Books { get; private set; } = new BindingList<Book>();

        public BookViewModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            LoadBooks();
        }

        public void LoadBooks()
        {
            var books = _bookRepository.GetAll();
            Books = new BindingList<Book>(books.ToList());
            OnPropertyChanged(nameof(Books));
        }

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            _bookRepository.Add(book);
            Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            _bookRepository.Update(book);
            LoadBooks();
        }

        public void DeleteBook(int bookId)
        {
            _bookRepository.Delete(bookId);
            var bookToRemove = Books.FirstOrDefault(b => b.BookId == bookId);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
            }
        }

        public void SearchBooks(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadBooks();
            }
            else
            {
                var results = _bookRepository.Search(keyword);
                Books = new BindingList<Book>(results.ToList());
                OnPropertyChanged(nameof(Books));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
