using System.ComponentModel.DataAnnotations;

namespace Lost.SharedLib
{
    public class PersonneViewModel : BaseViewModel
    {
        [Required(ErrorMessage = Constants.ErrorRequiredNom)]
        public string Nom { get; set; }

        [Required(ErrorMessage = Constants.ErrorRequiredPrenom)]
        public string Prenom { get; set; }

        public string Tel { get; set; }

        public bool IsPetiteMain { get; set; }

        public GroupeViewModel GroupeViewModel { get; set; }

        public TauxBlanchimentViewModel TauxBlanchimentViewModel { get; set; }

        public PersonneViewModel()
        {
            GroupeViewModel = new GroupeViewModel();
            TauxBlanchimentViewModel = new TauxBlanchimentViewModel();
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
