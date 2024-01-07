using System.Text;
using System.Text.Json;

namespace webapp
{
    public class AuthenticationAPI
    {
        public static async Task<bool> AuthenticateUser(string email, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiEndpoint = "https://web.socem.plymouth.ac.uk/COMP2001/auth/api/users";

                Login user = new Login
                {
                    Email = email,
                    Password = password
                };

                // Serialize the user object to JSON
                string jsonRequestBody = JsonSerializer.Serialize(user);

                // Prepare the HTTP request
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiEndpoint),
                    Method = HttpMethod.Post,
                    Content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json")
                };

                // Send the request and await the response
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // Throw an exception for non-success status codes

                // Read the response content
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the response JSON
                string[]? jsonResponseArray = JsonSerializer.Deserialize<string[]>(responseBody);

                // Check if the response array is valid
                if (jsonResponseArray == null || jsonResponseArray.Length < 2)
                {
                    return false;
                }

                // The user authorization status is at index 1 of the JSON Array returned from the API
                return bool.Parse(jsonResponseArray[1].ToLower());
            }
        }
    }
}
