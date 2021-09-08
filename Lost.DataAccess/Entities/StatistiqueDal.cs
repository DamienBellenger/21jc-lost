using Lost.DataAccess.Context;
using Lost.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lost.DataAccess.Entities
{
    public class StatistiqueDal
    {
        public static IList<Statistique> GetList()
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return dbContext.Statistique.AsNoTracking().ToList();
            }
        }

        public static async Task<IList<Statistique>> GetListAsync()
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return await dbContext.Statistique.AsNoTracking().ToListAsync();
            }
        }
    }
}
