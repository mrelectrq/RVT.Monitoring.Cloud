using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVT.Monitoring.Identity
{
    public static class Configuration
    {
        // public static string IDENTITYDB_CONNECION = "Server=AITPC\\SQLEXPRESS;Database=RVT.Monitoring.Identity;Trusted_Connection=True;MultipleActiveResultSets=true";
        //public static string IDENTITY_USERS_CONNECION = "Server=AITPC\\SQLEXPRESS;Database=RVT.Monitoring.Identity.User;Trusted_Connection=True;MultipleActiveResultSets=true";

        public static string IDENTITYDB_CONNECION = "Server=10.105.219.232,1433;Database=RVT.Monitoring.Identity;MultipleActiveResultSets=true;User Id=sa;password=Ar4iar4ikval;";
        public static string IDENTITY_USERS_CONNECION = "Server=10.105.219.232,1433;Database=RVT.Monitoring.Identity.User;MultipleActiveResultSets=true;User Id=sa;password=Ar4iar4ikval;";
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
                 {
                     new ApiResource("api1", "My API", new[] { JwtClaimTypes.Role })
             };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        new Client
        {
            ClientId = "ClientAPI",

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            //ClientSecrets =
            //{
            //    new Secret("ClientAPI".Sha256())
            //},              

            // scopes that client has access to
            AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,
                "api1", "rvt.profile" }
        },
        new Client
        {
            ClientId = "ClientBlazor",
            AllowedGrantTypes =GrantTypes.Code ,
            RequirePkce = true,
            RequireClientSecret  = false,
            AllowedCorsOrigins ={ "https://localhost:5001" },
            AllowedScopes = {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
                
                "rvt.profile","api1"},
            RedirectUris = { "https://localhost:5001/authentication/login-callback" },
            PostLogoutRedirectUris = { "https://localhost:5001/" },
            Enabled = true

        }
    };
        }


        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope (name:"api1", displayName:"Access api backend",userClaims: new[] { JwtClaimTypes.Role })
        };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var rvtProfile = new IdentityResource()
            {
                Name = "rvt.profile",
                DisplayName = "RVT Profile",
                UserClaims = new[] { "role" }
            };

            return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
           // new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new  ProfileWithRoles(),
            rvtProfile,
        };
        }



        public class ProfileWithRoles : IdentityResources.Profile
        {
            public ProfileWithRoles()
            {
                this.UserClaims.Add(JwtClaimTypes.Role);
            }
        }
    }
}
