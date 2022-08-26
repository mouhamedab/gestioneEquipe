using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ContratService:Service<Contrat>,IContratService
    {
        public ContratService(IUnitOfWork utwk) : base(utwk)
        {
        }
    }
}
