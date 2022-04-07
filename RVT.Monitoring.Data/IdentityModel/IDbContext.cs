using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Data.IdentityModel
{
   public interface IDbContext 
    {
        public DbSet<Entity> Set<Entity>() where Entity : class;
    }
}
