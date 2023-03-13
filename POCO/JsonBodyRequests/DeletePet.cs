using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpecflowBDD.POCO.JsonBodyRequests
{
    public class DeletePet
    {
        public async Task<int> DeleteExistingBooking()
        {
            var options = new RestClientOptions("https://petstore.swagger.io")
            {
                ThrowOnAnyError = true,
                MaxTimeout = 10000
            };

            var client = new RestClient(options);

            var request = new RestRequest("/v2/pet/100", Method.Delete);
            request.AddHeader("accept", "application/json");
            var response = await client.ExecuteAsync(request);
            int statusCode = (int)response.StatusCode;
            string responseBody = response.Content;
            Console.WriteLine("Response body is: " + responseBody);
            return statusCode;
        }
    }
}
