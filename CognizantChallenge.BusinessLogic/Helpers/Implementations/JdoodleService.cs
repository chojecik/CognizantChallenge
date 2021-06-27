using CognizantChallenge.BusinessLogic.Helpers.Interfaces;
using CognizantChallenge.BusinessLogic.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CognizantChallenge.BusinessLogic.Helpers.Implementations
{
    public class JdoodleService : IJdoodleService
    {
        private const string endpoint = "https://api.jdoodle.com/v1/execute";
        private readonly IHttpClientFactory clientFactory;

        public JdoodleService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        public async Task<JDoodleResponse> CallAsync(JDoodleRequest jdoodleRequest)
        {
            try
            {
                var client = clientFactory.CreateClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, endpoint);
                message.Headers.Add("Accept", "application/json");
                var json = JsonConvert.SerializeObject(jdoodleRequest);
                message.Content = new StringContent(json, Encoding.UTF8, "application/json");


                var response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<JDoodleResponse>(result);
                }
                    
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
