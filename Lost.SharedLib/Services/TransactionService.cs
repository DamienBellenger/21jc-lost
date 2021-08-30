using Lost.DataAccess.Entities;
using Lost.Model;
using Lost.SharedLib.Utils.Assembly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public class TransactionService : ITransactionService
    {
        public async Task<TransactionViewModel[]> GetAllAsync()
        {
            IList<Transaction> transactionList = await TransactionDal.GetListAsync();
            TransactionViewModel[] result = new TransactionViewModel[transactionList.Count];

            int i = 0;
            foreach (var transaction in transactionList.OrderBy(e => e.Id))
            {
                TransactionViewModel transactionViewModel = EntityToViewModel.FillViewModel<Transaction, TransactionViewModel>(transaction);

                result[i] = transactionViewModel;
                i++;
            }
            return await Task.FromResult(result);
        }

        public async Task<TransactionViewModel> GetAsync(long id)
        {
            Transaction transaction = await TransactionDal.GetAsync(id);

            TransactionViewModel transactionViewModel = EntityToViewModel.FillViewModel<Transaction, TransactionViewModel>(transaction);

            return transactionViewModel;
        }

        public async Task AddOrUpdateAsync(TransactionViewModel transactionViewModel)
        {
            Transaction transaction = ViewModelToEntity.FillEntity<TransactionViewModel, Transaction>(transactionViewModel);

            if (transactionViewModel.Id == 0)
            {
                await TransactionDal.AddAsync(transaction);
            }
            else
            {
                await TransactionDal.UpdateAsync(transaction);
            }
        }

        public async Task DeleteAsync(long id)
        {
            await TransactionDal.DeleteAsync(id);
        }

        public async Task<bool> CanBeDeleted(long id)
        {
            return await TransactionDal.CanBeDeleted(id);
        }
    }
}
