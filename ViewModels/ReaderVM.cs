using Quan_Ly_Thu_Vien_BTL_NET.Models;
using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Quan_Ly_Thu_Vien_BTL_NET.Views;

namespace Quan_Ly_Thu_Vien_BTL_NET.ViewModels
{
    public class ReaderViewModel : INotifyPropertyChanged
    {


        private readonly IReaderRepository _readerRepository;
        private BindingList<Reader> _readers;

        public BindingList<Reader> Readers
        {
            get => _readers;
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(Readers));
            }
        }

        public ReaderViewModel(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
            LoadData();
        }

        public void LoadData()
        {
            var list = _readerRepository.GetAll().ToList();
            Readers = new BindingList<Reader>(list);
        }

        public void AddReader(Reader reader)
        {
            _readerRepository.Add(reader);
            LoadData();
        }

        public void UpdateReader(Reader reader)
        {
            _readerRepository.Update(reader);
            LoadData();
        }

        public void DeleteReader(int readerId)
        {
            _readerRepository.Delete(readerId);
            LoadData();
        }

        public void Search(string keyword)
        {
            var results = _readerRepository.Search(keyword).ToList();
            Readers = new BindingList<Reader>(results);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}

