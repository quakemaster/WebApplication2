using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Produces("application/json")]
    [Route("api/Tests")]
    public class TestsController : Controller
    {
        private ApplicationDbContext _context;
        private ITestService _service;

        public TestsController(ApplicationDbContext context, ITestService service)
        {
            _context = context;
            _service = service;
        }

    

      
        // POST: api/Tests
        [HttpPost]
        public IActionResult PostTest([FromBody] Test test)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
            _service.AddTest(test);

            test = new Test();
            _context.Test.Where(f => f.Id == test.Id).FirstOrDefault();
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestExists(test.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTest", new { id = test.Id }, test);
        }

     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestExists(int id)
        {
            return _context.Test.Count(e => e.Id == id) > 0;
        }
    }
}