using System.ComponentModel.DataAnnotations;

namespace Lost.SharedLib
{
    public class UtilisateurViewModel : BaseViewModel
    {
        [Required(ErrorMessage = Constants.ErrorRequiredDiscordAuth)]
        public string DiscordAuth { get; set; }

        public PersonneViewModel PersonneViewModel { get; set; }
    }
}
