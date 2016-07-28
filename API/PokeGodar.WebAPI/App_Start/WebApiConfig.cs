﻿using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using PokeGodar.WebAPI.Cors;

namespace PokeGodar.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // This handles CORS requests globally.
            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            config.EnableCors();

            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
