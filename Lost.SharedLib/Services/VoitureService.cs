using Lost.DataAccess.Entities;
using Lost.Model;
using Lost.SharedLib.Utils.Assembly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public class VoitureService : IVoitureService
    {
        public async Task<VoitureViewModel[]> GetAllAsync()
        {
            IList<Voiture> voitureList = await VoitureDal.GetListWithPersonneAsync();
            VoitureViewModel[] result = new VoitureViewModel[voitureList.Count];

            int i = 0;
            foreach (var voiture in voitureList.OrderBy(e => e.Id))
            {
                VoitureViewModel voitureViewModel = EntityToViewModel.FillViewModel<Voiture, VoitureViewModel>(voiture);
                voitureViewModel.PersonneViewModel = EntityToViewModel.FillViewModel<Personne, PersonneViewModel>(voiture.Demandeur);

                result[i] = voitureViewModel;
                i++;
            }
            return await Task.FromResult(result);
        }

        public async Task AddOrUpdateAsync(VoitureViewModel voitureViewModel)
        {
            Voiture voiture = ViewModelToEntity.FillEntity<VoitureViewModel, Voiture>(voitureViewModel);
            voiture.DemandeurId = voitureViewModel.PersonneViewModel.Id;
            if (voitureViewModel.Id == 0)
            {
                Semaine semaine = await SemaineDal.GetLastAsync();
                //voiture.SemaineId = semaine.Id;
                await VoitureDal.AddAsync(voiture);
            }
            else
            {
                Voiture oldVoiture = await VoitureDal.GetAsync(voiture.Id);
                //voiture.SemaineId = oldVoiture.SemaineId;
                await VoitureDal.UpdateAsync(voiture);
            }
        }

        public async Task DeleteAsync(long id)
        {
            await VoitureDal.DeleteAsync(id);
        }

        public async Task<bool> CanBeDeleted(long id)
        {
            return true;//await VoitureDal.CanBeDeleted(id);
        }
    }
}
