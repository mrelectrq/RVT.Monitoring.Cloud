using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RVT.Monitoring.Data.MainModels;
using RVT.Monitoring.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ElectionController : Controller
    {
        private readonly IElectionService _bl;

        public ElectionController(IElectionService electionService)
        {
            _bl = electionService;

        }

        public Election GetElectionById(Guid ID)
        {

            return _bl.GetElection(m => m.ElectionId == ID);
        }


       
    }
}
