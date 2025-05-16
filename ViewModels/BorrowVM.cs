using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Quan_Ly_Thu_Vien_BTL_NET.Models;
using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;

namespace Quan_Ly_Thu_Vien_BTL_NET.ViewModels
{
    public class BorrowVM : INotifyPropertyChanged
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly ISystemConfigRepository _configRepository;

        private List<Borrow> _borrowRecords;
        public List<Borrow> BorrowRecords
        {
            get => _borrowRecords;
            private set { _borrowRecords = value; OnPropertyChanged(); }
        }

        private List<Book> _books;
        public List<Book> Books
        {
            get => _books;
            private set { _books = value; OnPropertyChanged(); }
        }

        private List<Reader> _readers;
        public List<Reader> Readers
        {
            get => _readers;
            private set { _readers = value; OnPropertyChanged(); }
        }

        private SystemConfig _config;

        public BorrowVM(
            IBorrowRepository borrowRepository,
            IBookRepository bookRepository,
            IReaderRepository readerRepository,
            ISystemConfigRepository configRepository)
        {
            _borrowRepository = borrowRepository ?? throw new ArgumentNullException(nameof(borrowRepository));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _readerRepository = readerRepository ?? throw new ArgumentNullException(nameof(readerRepository));
            _configRepository = configRepository ?? throw new ArgumentNullException(nameof(configRepository));

            LoadConfig();
            Refresh();
        }

        public int MaxBorrowDays => _config?.MaxBorrowDays ?? 7;

        private void LoadConfig()
        {
            _config = _configRepository.GetConfig();
            if (_config == null)
            {
                // Nếu không có config, đặt mặc định
                _config = new SystemConfig()
                {
                    MaxBorrowDays = 7,
                    MaxBooksPerReader = 3,
                    FinePerDay = 1000m
                };
            }
        }

        public void Refresh()
        {
            BorrowRecords = _borrowRepository.GetAll() ?? new List<Borrow>();
            Books = _bookRepository.GetAll()?.ToList() ?? new List<Book>();
            Readers = _readerRepository.GetAll()?.ToList() ?? new List<Reader>();

        }

        public void BorrowBook(int readerId, int bookId, DateTime borrowDate, DateTime dueDate)
        {
            var book = Books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
                throw new Exception("Không tìm thấy sách.");

            if (book.Quantity <= 0)
                throw new InvalidOperationException("Sách hiện không còn để mượn.");

            var reader = Readers.FirstOrDefault(r => r.ReaderId == readerId);
            if (reader == null)
                throw new Exception("Không tìm thấy độc giả.");

            // Kiểm tra số sách độc giả đã mượn chưa trả
            int currentBorrowCount = _borrowRepository.GetBorrowsByReaderId(readerId)
                .Count(b => b.ReturnDate == null);

            if (currentBorrowCount >= (_config?.MaxBooksPerReader ?? 3))
                throw new InvalidOperationException($"Độc giả đã mượn tối đa {_config.MaxBooksPerReader} cuốn sách.");

            var borrow = new Borrow
            {
                BookId = bookId,
                ReaderId = readerId,
                BorrowDate = borrowDate,
                DueDate = borrowDate.AddDays(MaxBorrowDays), // tự động tính hạn trả dựa vào cấu hình
                IsRenewed = false
            };

            _borrowRepository.Add(borrow);

            // Giảm số lượng sách còn lại
            book.Quantity--;
            _bookRepository.Update(book);

            Refresh();
        }

        public void ReturnBook(int borrowId)
        {
            var borrow = BorrowRecords.FirstOrDefault(b => b.BorrowId == borrowId);
            if (borrow == null)
                throw new Exception("Không tìm thấy phiếu mượn.");

            if (borrow.ReturnDate != null)
                throw new InvalidOperationException("Sách đã được trả.");

            _borrowRepository.MarkAsReturned(borrowId);

            // Tăng số lượng sách sau khi trả
            var book = Books.FirstOrDefault(b => b.BookId == borrow.BookId);
            if (book != null)
            {
                book.Quantity++;
                _bookRepository.Update(book);
            }

            Refresh();
        }

        public void RenewBook(int borrowId)
        {
            var borrow = BorrowRecords.FirstOrDefault(b => b.BorrowId == borrowId);
            if (borrow == null)
                throw new Exception("Không tìm thấy phiếu mượn.");

            if (borrow.IsRenewed)
                throw new InvalidOperationException("Sách đã được gia hạn lần rồi.");

            if (borrow.ReturnDate != null)
                throw new InvalidOperationException("Sách đã được trả, không thể gia hạn.");

            // Gia hạn hạn trả thêm 
            borrow.DueDate = borrow.DueDate.AddDays(MaxBorrowDays);
            borrow.IsRenewed = true;

            _borrowRepository.Update(borrow); 

            Refresh();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
