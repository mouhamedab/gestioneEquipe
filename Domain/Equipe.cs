using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Equipe
    {
        public string AdresseLocal { get; set; }
        public int EquipeId { get; set; }
        public string Logo { get; set; }
        public string NomEquipe { get; set; }
        public virtual IList<Trophee> Trophees { get; set; }
        public virtual IList<Contrat> Contrats { get; set; }
    }
}
