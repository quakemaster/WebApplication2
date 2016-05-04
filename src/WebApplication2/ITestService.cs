using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface ITestService
    {
        Task AddTest(Test model);
    }
}