using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contoso.Transport.Services;
using Newtonsoft.Json;
using System.Net.Http;
using Contoso.Transport.Services.Models;

namespace Contoso.Transport.Services.Test
{
	[TestClass]
	public class PackageControllerTests
	{
		[TestMethod]
		public async Task FindPackageByIdNotNullTest()
		{
			var packageid = 1;
			var packageUrl = string.Format("http://localhost:4004/api/package/{0}", packageid);
			using (HttpClient client = new HttpClient())
			{
				string response = await client.GetStringAsync(packageUrl);
				Assert.IsNotNull(response);
				Package package = await Task.Factory.StartNew(() =>
					JsonConvert.DeserializeObject<Package>(response));
				Assert.IsNotNull(package);
				Assert.AreEqual(packageid, package.Id);
			}
		}
	}
}
