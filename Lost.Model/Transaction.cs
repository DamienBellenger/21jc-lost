using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Lost.Model
{
    public class Transaction : IdEntity
    {
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("qty_sac")]
        public int NbSac { get; set; }

        [Column("qty_voiture")]
        public int NbVoiture { get; set; }

        [Column("qty_billet")]
        public int NbBillet { get; set; }

        [ForeignKey(nameof(SemaineId))]
        public Semaine Semaine { get; set; }

        [ForeignKey(nameof(Semaine))]
        [Column("id_semaine")]
        public long? SemaineId { get; set; }

        [ForeignKey(nameof(PayeParId))]
        public Personne PayePar { get; set; }

        [ForeignKey(nameof(PayePar))]
        [Column("id_payepar")]
        public long? PayeParId { get; set; }

        [ForeignKey(nameof(TauxBlanchimentId))]
        public TauxBlanchiment TauxBlanchiment { get; set; }

        [ForeignKey(nameof(TauxBlanchiment))]
        [Column("id_taux_blanchiment")]
        public long? TauxBlanchimentId { get; set; }
    }
}
