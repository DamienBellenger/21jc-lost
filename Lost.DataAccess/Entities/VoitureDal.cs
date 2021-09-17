using Lost.DataAccess.Context;
using Lost.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lost.DataAccess.Entities
{
    public class VoitureDal : LostContextDal<Voiture>
    {
        public static async Task<List<Voiture>> GetListWithPersonneAsync()
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return await dbContext.Voiture.AsNoTracking().Include(u => u.Demandeur).ToListAsync();
            }
        }
    }
}
