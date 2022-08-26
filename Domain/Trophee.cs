using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public enum TypeTrophee
    {
        Coupe,
        Championnat
    }
    public class Trophee
    {
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public double Recompense { get; set; }
        public int TropheeId { get; set; }
        public TypeTrophee TypeTrophee { get; set; }
        public int EquipeFK { get; set; }
        public virtual Equipe Equipe { get; set; }
    }
}
