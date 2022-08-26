using Domain;
using Microsoft.Extensions.DependencyInjection;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EquipeService:Service<Equipe>,IEquipeService
    {
        public EquipeService(IUnitOfWork utwk) : base(utwk)
        {
        }

        public DateTime DatePremierChampionat(Equipe e)
        {
            return e.Trophees.Where(t => t.TypeTrophee == TypeTrophee.Championnat)
                .OrderBy(t => t.DateTrophee).First().DateTrophee;
        }

        public List<Entraineur> ListeEntraineurParEquipe(Equipe e)
        {
         
            return e.Contrats.Select(c => c.Membre).OfType<Entraineur>().ToList();
        }

        public List<Joueur> ListeJoueurTrophee(Trophee t)
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            IContratService cs = new ContratService(uow);
            return cs.GetMany(c => (t.DateTrophee - c.DateContrat).
            TotalDays < c.DureeMois * 30).
            Select(c => c.Membre).OfType<Joueur>().ToList();
        }

        public double SommeRecompense(Equipe e)
        {
            double somme = 0;
            foreach(var t in e.Trophees)
            {
                somme = somme + t.Recompense;
            }
            return somme;
        }
    }
}
