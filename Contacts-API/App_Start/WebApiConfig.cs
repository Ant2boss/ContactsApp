using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Contacts_API
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();
			
			config.Routes.MapHttpRoute(
				name: "ContactsDefault",
				routeTemplate: "api/Contacts",
				defaults: new { controller = "Contacts", action = "GetList" }
			);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}",
				defaults: new { }
			);
		}
	}
}
