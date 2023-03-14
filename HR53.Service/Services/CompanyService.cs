using HR53.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _db;
        public CompanyService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task GetAllAsync()
        {
            var companies = await _db.Companies.ToListAsync();
        }
    }
}
