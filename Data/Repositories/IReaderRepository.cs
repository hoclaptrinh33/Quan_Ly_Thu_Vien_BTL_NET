using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_Thu_Vien_BTL_NET.Models;

namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{ 
        public interface IReaderRepository
        {
            IEnumerable<Reader> GetAll();
            Reader GetById(int readerId);
            void Add(Reader reader);
            void Update(Reader reader);
            void Delete(int readerId);
            IEnumerable<Reader> Search(string keyword);
        }
    }


