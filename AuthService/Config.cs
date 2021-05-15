using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "auth_client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("auth_secret_228".Sha256())
                    },
                    AllowedScopes = 
                    {
                        "auth.admin"
                    },
                    AllowedCorsOrigins = new List<string> { "http://localhost", "http://localhost:3000" },
                    Enabled = true,
                },
                new Client
                {
                    ClientId = "nuxt_ssr",

                    //AllowedGrantTypes = GrantTypes.Code,

                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,

                    AllowedScopes = { "auth.admin", IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    RequireConsent = false,
                    RequirePkce = false,
                    RequireClientSecret = false,
                    Enabled = true,
                    //RedirectUris = { "http://localhost:3000/callback", "http://localhost:3000/login" },
                    RedirectUris = { "http://localhost:3000/login" },
                    PostLogoutRedirectUris = { "http://localhost:3000" },
                    AllowedCorsOrigins = new List<string> { "http://localhost", "http://localhost:3000" },
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("auth.admin"),
                new ApiScope("auth.operator"),
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources() 
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
