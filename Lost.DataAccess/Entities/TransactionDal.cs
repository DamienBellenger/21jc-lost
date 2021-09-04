using Lost.DataAccess.Context;
using Lost.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lost.DataAccess.Entities
{
    public class TransactionDal : LostContextDal<Transaction>
    {
        public static async Task<List<Transaction>> GetListWithDetailsAsync()
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return await dbContext.Transaction
                    .Include(t => t.Semaine)
                    .Include(t => t.TauxBlanchiment.Groupe)
                    .Include(t => t.TauxBlanchiment.Personne)
                    .AsNoTracking().ToListAsync();
            }
        }

        public static async Task<Transaction> GetWithDetailsAsync(long id)
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return await dbContext.Transaction
                    .Include(t => t.TauxBlanchiment.Groupe)
                    .Include(t => t.TauxBlanchiment.Personne)
                    .AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public static async Task<bool> CanBeDeleted(long idTransaction)
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return true;
            }
        }
    }
}
