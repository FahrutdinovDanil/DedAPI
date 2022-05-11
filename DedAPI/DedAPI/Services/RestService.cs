using DedAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DedAPI.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions options;
        RootModel rootModel { get; set; }
        public RestService()
        {
            client = new HttpClient();
           
        }
        public async Task<List<EntryModel>> GetDataAsync()
        {

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty)); 
            try
            {
                Debug.WriteLine("Start Requests");
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                Debug.WriteLine("End Request");

                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();   
                    rootModel = JsonSerializer.Deserialize<RootModel>(content);
                }
                else
                {
                    Debug.WriteLine("Bad Requset");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return rootModel.entries;
        }
    }
}
