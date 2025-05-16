using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        List<Category> Search(string keyword);
    }
}
