using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace DangerZoneHackerTracker
{
	public static class WebReader
	{
		public static readonly HttpClient httpClient = new HttpClient();

		public static async Task<string> ReadToEndAsync(string url)
		{
			try
			{
				string responseBody = await httpClient.GetStringAsync(url);
				return responseBody;
			}
			catch (HttpRequestException)
            {
				return null;
			}
		}
	}
}
