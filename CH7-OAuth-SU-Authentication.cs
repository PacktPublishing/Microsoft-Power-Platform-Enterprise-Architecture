using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;

static void Main(string[] args)
{
    string url = "https://contoso.crm.dynamics.com";
    string clientId = "51f81489-12ee-4a9e-aaae-a2591f45987d";
    string username = "user@contoso.onmicrosoft.com";
    string password = "Pass@rowd1";

    AuthenticationContext authContext = new AuthenticationContext("https://login.microsoftonline.com/common", false);
    UserCredential credential = new UserCredential(username, password);
    AuthenticationResult result = authContext.AcquireToken(url, clientId, credential);

    string accessToken = result.AccessToken;
    using (HttpClient client = new HttpClient())
    {
        client.BaseAddress = new Uri(url);
        client.Timeout = new TimeSpan(0, 2, 0);
        client.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
        client.DefaultRequestHeaders.Add("OData-Version", "4.0");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "/api/data/v9.1/WhoAmI");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        HttpResponseMessage response = client.SendAsync(request).Result;
        if (response.IsSuccessStatusCode)
        {
            //Get the response content and parse it. 
            JObject body = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            Guid userId = (Guid)body["UserId"];
            Console.WriteLine("Your userid = {0}", userId);
        }
    }
}
