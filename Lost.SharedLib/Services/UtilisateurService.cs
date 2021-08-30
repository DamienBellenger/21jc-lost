using Lost.DataAccess.Entities;
using Lost.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public class UtilisateurService : IUtilisateurService
    {
        public async Task<UtilisateurViewModel[]> GetAllAsync()
        {
            IList<Utilisateur> utilisateurList = await UtilisateurDal.GetListWithPersonneAndGroupeAsync();
            UtilisateurViewModel[] result = new UtilisateurViewModel[utilisateurList.Count];

            int i = 0;
            foreach (var utilisateur in utilisateurList.OrderBy(e => e.Id))
            {
                UtilisateurViewModel utilisateurViewModel = EntityToViewModel.FillViewModel<Utilisateur, UtilisateurViewModel>(utilisateur);
                utilisateurViewModel.PersonneViewModel = EntityToViewModel.FillViewModel<Personne, PersonneViewModel>(utilisateur.Personne);
                if(utilisateur.Personne.Groupe != null)
                {
                    utilisateurViewModel.PersonneViewModel.GroupeViewModel = EntityToViewModel.FillViewModel<Groupe, GroupeViewModel>(utilisateur.Personne.Groupe);
                }
                result[i] = utilisateurViewModel;
                i++;
            }
            return await Task.FromResult(result);
        }
    }
}
