﻿using Lost.DataAccess.Entities;
using Lost.Model;
using Lost.SharedLib.Utils.Assembly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lost.SharedLib
{
    public class PersonneService : IPersonneService
    {
        public async Task<PersonneViewModel[]> GetAllAsync()
        {
            IList<Personne> personneList = await PersonneDal.GetListAsync();
            PersonneViewModel[] result = new PersonneViewModel[personneList.Count];

            int i = 0;
            foreach (var personne in personneList.OrderBy(e => e.Id))
            {
                PersonneViewModel personneViewModel = EntityToViewModel.FillViewModel<Personne, PersonneViewModel>(personne);

                result[i] = personneViewModel;
                i++;
            }
            return await Task.FromResult(result);
        }

        public async Task<PersonneViewModel> GetAsync(long id)
        {
            Personne personne = await PersonneDal.GetAsync(id);
            TauxBlanchiment tauxBlanchiment = await TauxBlanchimentDal.GetLastTauxBlanchimentPersonneAsync(id);

            PersonneViewModel personneViewModel = EntityToViewModel.FillViewModel<Personne, PersonneViewModel>(personne);

            if (tauxBlanchiment != null)
            {
                personneViewModel.TauxBlanchimentViewModel = EntityToViewModel.FillViewModel<TauxBlanchiment, TauxBlanchimentViewModel>(tauxBlanchiment);

            }

            return personneViewModel;
        }

        public async Task AddOrUpdateAsync(PersonneViewModel personneViewModel)
        {
            Personne personne = ViewModelToEntity.FillEntity<PersonneViewModel, Personne>(personneViewModel);

            if (!personne.IsPetiteMain)
            {
                personne.GroupeId = personneViewModel.GroupeViewModel?.Id;
            }

            if (personneViewModel.Id == 0)
            {
                await PersonneDal.AddAsync(personne);
            }
            else
            {
                await PersonneDal.UpdateAsync(personne);
            }

            if (personne.IsPetiteMain)
            {
                TauxBlanchiment tauxBlanchiment = ViewModelToEntity.FillEntity<TauxBlanchimentViewModel, TauxBlanchiment>(personneViewModel.TauxBlanchimentViewModel);
                tauxBlanchiment.DateDebut = System.DateTime.Now;
                tauxBlanchiment.PersonneId = personne.Id;
                tauxBlanchiment.Id = 0;
                await TauxBlanchimentDal.AddAsync(tauxBlanchiment);
            }
        }

        public async Task DeleteAsync(long id)
        {
            await PersonneDal.DeleteAsync(id);
        }

        public async Task<bool> CanBeDeleted(long id)
        {
            return await PersonneDal.CanBeDeleted(id);
        }
    }
}
