using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public interface ISemaineService
    {
        public Task<SemaineViewModel> GetLastAsync();
    }
}
