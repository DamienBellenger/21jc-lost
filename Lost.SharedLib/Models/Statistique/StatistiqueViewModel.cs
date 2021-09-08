using System.ComponentModel.DataAnnotations;

namespace Lost.SharedLib
{
    public class StatistiqueViewModel : BaseViewModel
    {
        public string Nom { get; set; }
        public int Numero { get; set; }
        public double Billet { get; set; }
        public double Sac { get; set; }
        public double Voiture { get; set; }
        public double Benefice { get; set; }

        public StatistiqueViewModel()
        {
            
        }
    }
}
