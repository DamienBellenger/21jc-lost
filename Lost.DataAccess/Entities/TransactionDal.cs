using Lost.DataAccess.Context;
using Lost.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lost.DataAccess.Entities
{
    public class TransactionDal : LostContextDal<Transaction>
    {
        public static async Task<bool> CanBeDeleted(long idTransaction)
        {
            using (LostDbContext dbContext = CommonDal.CreateDbContext())
            {
                return true;
            }
        }
    }
}
