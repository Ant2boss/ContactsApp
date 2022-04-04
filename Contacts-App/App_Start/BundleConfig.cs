using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Contacts_App.App_Start
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(
				new ScriptBundle("~/bundles/css").Include(
						 "~/Content/bootstrap.min.css"
						 )
				);

			bundles.Add(
				new ScriptBundle("~/bundles/js").Include(
						 "~/Scripts/bootstrap.bundle.min.js"
						 )
				);
		}
	}
}