using RestSharp;
using System;
using System.Threading.Tasks;

namespace SpecflowBDD.POCO.JsonBodyRequests
{
    public class CreateBooking
    {
        string createBrandNewBooking = "{ \r\n" +
                                          "\"firstname\": \"JQ\",\r\n" +
                                          "\"lastname\": \"Test\",\r\n" +
                                          "\"totalprice\": \"4000\",\r\n" +
                                          "\"depositpaid\": \"true\",\r\n" +
                                          "\"bookingdates\":\r\n" +
                                            "{\r\n" +
                                                "\"checkin\": \"2018-01-01\",\r\n" +
                                                "\"checkout\": \"2019-01-01\"\r\n" +
                                            "},\r\n" +
                                           "\"additionalneeds\": \"Breakfast\"\r\n" +
                                         "}";


        public async Task<int> CreateBrandNewBooking()
        {
            var options = new RestClientOptions("https://restful-booker.herokuapp.com")
            {
                ThrowOnAnyError = true,
                MaxTimeout = 10000
            };

            var client = new RestClient(options);

            var request = new RestRequest("/booking", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.AddJsonBody(createBrandNewBooking);
            var response = await client.ExecuteAsync(request);
            int statusCode = (int)response.StatusCode;
            string responseBody = response.Content;
            Console.WriteLine("Response body is: " + responseBody);
            return statusCode;
        }
    }
}
