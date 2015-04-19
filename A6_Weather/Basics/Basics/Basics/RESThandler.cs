using System;
using RestSharp;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Basics
{
	public class RESTHandler
	{
		private string url;
		private IRestResponse response;

		public RESTHandler ()
		{
			url = "";
		}

		public RESTHandler(string lurl)
		{
			url = lurl;
		}
			

		public async Task<OneDay.Cities> ExecuteOneDayAsync()
		{
			var client = new RestClient (url);
			var request = new RestRequest ();

			response = await client.ExecuteTaskAsync (request);

			XmlSerializer serializer = new XmlSerializer (typeof(OneDay.Cities));
			OneDay.Cities objRootdata;

			TextReader sr = new StringReader (response.Content);
			objRootdata = (OneDay.Cities)serializer.Deserialize (sr);
			return objRootdata;
		}

		public async Task<FiveDays.Weatherdata> ExecuteFiveDaysAsync()
		{
			var client = new RestClient (url);
			var request = new RestRequest ();

			response = await client.ExecuteTaskAsync (request);

			XmlSerializer serializer = new XmlSerializer (typeof(FiveDays.Weatherdata));
			FiveDays.Weatherdata objWeatherdata;

			TextReader sr = new StringReader (response.Content);
			objWeatherdata = (FiveDays.Weatherdata)serializer.Deserialize (sr);
			return objWeatherdata;
		}
	}
}

