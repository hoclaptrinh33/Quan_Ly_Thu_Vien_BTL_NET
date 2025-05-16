using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_Thu_Vien_BTL_NET.Models;


namespace Quan_Ly_Thu_Vien_BTL_NET.Data.Repositories
{

    public class SystemConfigRepository : ISystemConfigRepository
    {
        private readonly AppDbContext _context;

        public SystemConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public SystemConfig GetConfig()
        {
            return _context.SystemConfigs.FirstOrDefault();
        }

        public void UpdateConfig(SystemConfig config)
        {
            _context.SystemConfigs.Update(config);
            _context.SaveChanges();
        }
    }
}


