using RVT.Monitoring.Data.IdentityModel;
using RVT.Monitoring.Data.MainModels;
using RVT.Monitoring.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Services.Concrete
{
    public class ElectionService : IElectionService
    {
        private readonly UserDbContext _context;
        public ElectionService(UserDbContext dbContext)
        {
            _context = dbContext;
        }

        public Election CreateElection(Election election)
        {
           var data= _context.Elections.Add(election);
            _context.SaveChanges();
            return data.Entity;
        }

        public IEnumerable<Election> FindAll(Expression<Func<Election, bool>> match)
        {
            var data = _context.Elections.Where(match).ToList();
            return data;
        }

        public Election GetElection(Expression<Func<Election, bool>> match)
        {
          return  _context.Elections.FirstOrDefault(match);
        }

        public bool StartElection(Election election)
        {
            if(election.StartTime == null || election.ClosureTime == null)
            {
                return false;
            }

            _context.Update(election);
            _context.SaveChanges();
            return true;

        }

        public bool StopElection(Election election)
        {
            if(election.ClosureTime == null || election.ClosureTime< DateTime.Now)
            {
                return false;
            }

            _context.Update(election);
            _context.SaveChanges();
            return true;
        }
    }
}
