using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVT.Monitoring.Shared
{
    public static class Config
    {
        //public static string IDENTITY_USERS_CONNECION = "Server=AITPC\\SQLEXPRESS;Database=RVT.Monitoring.Identity.User;Trusted_Connection=True;MultipleActiveResultSets=true";
       // public static string IDENTITYDB_CONNECION = "Server=AITPC\\SQLEXPRESS;Database=RVT.Monitoring.Identity;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static string IDENTITY_USERS_CONNECION = "Server=127.0.0.1,1433;Database=RVT.Monitoring.Identity.User;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=sa;password=Ar4iar4ikval";
        public static string IDENTITYDB_CONNECION = "Server=127.0.0.1,1433;Database=RVT.Monitoring.Identity;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=sa;password=Ar4iar4ikval";
        public static string IDENTITY_HOST = "https://localhost:5000/";
        public static string IDENTITY_APINAME = "api1";
        public static string CLIENT_ID_BLAZOR = "ClientBlazor";
    }
}
