using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpecflowBDD.POCO.JsonBodyRequests
{
    public class ReadBookingsIds
    {
        public async Task<int> GetBookingIds()
        {
            var options = new RestClientOptions("https://restful-booker.herokuapp.com")
            {
                ThrowOnAnyError = true,
                MaxTimeout = 10000
            };

            var client = new RestClient(options);

            var request = new RestRequest("/booking", Method.Get);
            var response = await client.ExecuteAsync(request);
            int statusCode = (int)response.StatusCode;
            Console.WriteLine("Response status code is: " + statusCode);
            return statusCode;
        }
    }
}
