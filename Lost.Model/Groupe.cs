﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lost.Model
{
    public class Groupe : IdEntity
    {
        [Column("nom")]
        public string Nom { get; set; }

        [Column("groupe_cartel")]
        public bool IsGroupeCartel { get; set; }

        public List<TauxBlanchiment> TauxBlanchiment { get; set; }
    }
}
