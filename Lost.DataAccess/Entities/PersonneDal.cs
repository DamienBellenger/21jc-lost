using Lost.DataAccess.Context;
using Lost.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public static async Task<List<Personne>> GetListWithTauxAsync()
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                List<Personne> personnes = await dbContext.Personne.AsNoTracking().ToListAsync();
                foreach(Personne personne in personnes)
                {
                    personne.TauxBlanchiment = await TauxBlanchimentDal.GetLastTauxBlanchimentPersonneAsync(personne.Id);
                }
                return personnes;
            }
        }
    }
}
