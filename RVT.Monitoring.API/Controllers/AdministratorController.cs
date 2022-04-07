using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RVT.Monitoring.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.API.Controllers
{
  //  [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]

    public class AdministratorController : ControllerBase
    {
       // private readonly IAdministratorActions _bl;
        //public AdministratorController(ServiceManager serviceManager)
        //{
        //    _bl = serviceManager.GetAdministratorActions();
        //}
        
        //[HttpGet]
        //[Route("getuserlist/{startIndex}/{pagesize}")]   
        //public List<RVTUserModel> GetUsersList( int startIndex, int pagesize)
        //{
        //    var response = _bl.GetRVTUsers(startIndex, pagesize);
        //    return response;
        //}
        

    }
}
