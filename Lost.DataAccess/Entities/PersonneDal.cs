using Lost.DataAccess.Context;
using Lost.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lost.DataAccess.Entities
{
    public class PersonneDal : LostContextDal<Personne>
    {
        public static async Task<bool> CanBeDeleted(long idGroupe)
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return true;
            }
        }
    }
}
