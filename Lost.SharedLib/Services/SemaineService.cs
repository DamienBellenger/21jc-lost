using Lost.DataAccess.Entities;
using Lost.Model;
using Lost.SharedLib.Utils.Assembly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public class SemaineService : ISemaineService
    {
        public async Task<SemaineViewModel> GetLastAsync()
        {
            Semaine semaine = await SemaineDal.GetLastAsync();
            SemaineViewModel semaineViewModel = EntityToViewModel.FillViewModel<Semaine, SemaineViewModel>(semaine);
            return semaineViewModel;
        }
    }
}
