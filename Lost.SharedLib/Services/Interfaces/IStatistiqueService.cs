using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public interface IStatistiqueService
    {
        public Task<StatistiqueViewModel[]> GetAllAsync();
    }
}
