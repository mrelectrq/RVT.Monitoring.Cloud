using RVT.Monitoring.Data.MainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Services.Interfaces
{
    public interface IElectionService
    {
        Election GetElection(Expression<Func<Election,bool>> match);
        Election CreateElection(Election election);
        IEnumerable<Election> FindAll(Expression<Func<Election, bool>> match);
        bool StartElection(Election election);
        bool StopElection(Election election);
    }
}
