using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Contrat
    {
        public DateTime DateContrat { get; set; }
        [Range(0,24)]
        public int DureeMois { get; set; }
        public double Salaire { get; set; }
       // [ForeignKey("Equipe")]
        public int EquipeFK { get; set; }
        [ForeignKey("EquipeFK")]
        public virtual Equipe Equipe { get; set; }
        //[ForeignKey("Membre")]
        public int MembreFK { get; set; }
        [ForeignKey("MembreFK")]
        public virtual Membre Membre { get; set; }

    }
}
