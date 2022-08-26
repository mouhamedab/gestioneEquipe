using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Membre
    {
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Key]
        public int Identifiant { get; set; }
        [Required(ErrorMessage ="Le champ nom est obligatoire ")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ prénom est obligatoire ")]
        public string Prenom { get; set; }
        public virtual IList<Contrat> Contrats { get; set; }
    }
}
