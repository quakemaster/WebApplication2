using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class TestService : ITestService
    {
        private ApplicationDbContext _context;

        public TestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Test1(Test model)
        {
            
                model = new Test();
                int sss = model.Id;
                _context.Test.Where(f => f.Id == sss).FirstOrDefault();
         
        }
    }
}
