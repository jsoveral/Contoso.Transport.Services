#region using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Contoso.Transport.Services.Models;

#endregion


namespace Contoso.Transport.Services.Controllers
{
	public class PackageController : ApiController
	{
		private static IEnumerable<Package> packages;

		public Package Get(int id)
		{
			return packages.SingleOrDefault(p => p.Id == id);
		}

		protected override void Initialize(HttpControllerContext controlerContext)
		{
			base.Initialize(controlerContext);

			GenerateStubs();
		}

		private static void GenerateStubs()
		{
			Guid test = Guid.NewGuid();

			packages = new List<Package>()
			{
				new Package
				{
					Id = 1,
					AccountNumber = Guid.NewGuid(),
					Destination = "LX",
					Origin = "DUB",
					StatusCode = 1,
					Units = 1,
					Weight = 2.5,
					Created = DateTime.UtcNow
				},
				new Package
				{
					Id = 2,
					AccountNumber = Guid.NewGuid(),
					Destination = "AZ",
					Origin = "AL",
					StatusCode = 1,
					Units = 2,
					Weight = 1,
					Created = DateTime.UtcNow.AddDays(-2)
				},
				new Package
				{
					Id = 3,
					AccountNumber = Guid.NewGuid(),
					Destination = "LON",
					Origin = "Barril",
					StatusCode = 3,
					Units = 2,
					Weight = 1,
					Created = DateTime.UtcNow.AddDays(2)
				}
			};
		}
	}
}
