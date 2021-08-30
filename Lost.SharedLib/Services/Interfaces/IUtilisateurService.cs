using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public interface IUtilisateurService
    {
        public Task<UtilisateurViewModel[]> GetAllAsync();
    }
}
