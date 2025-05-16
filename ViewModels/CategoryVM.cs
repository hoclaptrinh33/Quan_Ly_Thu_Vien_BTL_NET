using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Quan_Ly_Thu_Vien_BTL_NET.Data;
using Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.ViewModels
{
    public class CategoryVM : INotifyPropertyChanged
    {
        private readonly ICategoryRepository _repository;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Category> Categories { get; private set; }
        public string CategoryName { get; set; }

        public CategoryVM()
        {
            _repository = new CategoryRepository(new AppDbContext());
            LoadCategories();
        }

        public void LoadCategories()
        {
            Categories = _repository.GetAll();
            Notify("Categories");
        }

        public void AddCategory(string name)
        {
            var category = new Category { CategoryName = name };
            _repository.Add(category);
            LoadCategories();
        }

        public void UpdateCategory(int id, string name)
        {
            var category = _repository.GetById(id);
            if (category != null)
            {
                category.CategoryName = name;
                _repository.Update(category);
                LoadCategories();
            }
        }

        public void DeleteCategory(int id)
        {
            _repository.Delete(id);
            LoadCategories();
        }

        public void Search(string keyword)
        {
            Categories = _repository.Search(keyword);
            Notify("Categories");
        }

        private void Notify(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
