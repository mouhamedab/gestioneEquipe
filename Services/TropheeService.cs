using Domain;
using PS.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
  public  class TropheeService : Service<Trophee>, ITropheeService
    {
        public TropheeService(IUnitOfWork utwk) : base(utwk)
        {
        }
    }
}
