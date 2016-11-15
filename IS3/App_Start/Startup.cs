using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IS3.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace IS3.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Embedded IdentityServer",
                    SigningCertificate = LoadCertificate(),

                    Factory = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(IdentityServer.Users.Get())
                                .UseInMemoryClients(IdentityServer.Clients.Get())
                                .UseInMemoryScopes(StandardScopes.All)
                });
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44335/identity",
                ClientId = "mvc",
                RedirectUri = "https://localhost:44335/",
                ResponseType = "id_token",

                SignInAsAuthenticationType = "Cookies"
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\IdentityServer\idsrv3test.pfx", AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}