using Lost.DataAccess.Entities;
using Lost.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public class StatistiqueService : IStatistiqueService
    {
        public async Task<StatistiqueViewModel[]> GetAllAsync()
        {
            IList<Statistique> statistiqueList = await StatistiqueDal.GetListAsync();
            StatistiqueViewModel[] result = new StatistiqueViewModel[statistiqueList.Count];

            int i = 0;
            foreach (var statistique in statistiqueList)
            {
                StatistiqueViewModel statistiqueViewModel = new StatistiqueViewModel();
                statistiqueViewModel.Benefice = statistique.Benefice;
                statistiqueViewModel.Billet = statistique.Billet;
                statistiqueViewModel.Nom = statistique.Nom;
                statistiqueViewModel.Numero = statistique.Numero;
                statistiqueViewModel.Sac = statistique.Sac;
                statistiqueViewModel.Voiture = statistique.Voiture;
                result[i] = statistiqueViewModel;
                i++;
            }
            return await Task.FromResult(result);
        }
    }
}
