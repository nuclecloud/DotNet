using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Nucle.Cloud.Models;

namespace Nucle.Cloud.Controllers
{
    public class Event
    {
 
        public static async Task<EventModel> Register(string projectId, string deviceId, string displayName = null)
        {
            var model = new { deviceId = deviceId, displayName = displayName };
            var url = "https://api.nucle.cloud/v1/event/register";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<EventModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }
 

        public static async Task<EventModel> Get(string projectId, string presetId)
        {
            var model = new { presetId = presetId };
            var url = "https://api.nucle.cloud/v1/event/get";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<EventModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }


        public static async Task<EventModel> GetList(string projectId, string presetId, int skip = 0, int take = 10, orderType orderType = orderType.Newest)
        {
            int _orderType = (int)orderType;
            var args = new { skip, take, _orderType };
            var model = new { presetId, args };
            var url = "https://api.nucle.cloud/v1/event/get";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<EventModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<EventModel> Delete(string projectId, string presetId)
        {
            var model = new { presetId = presetId };
            var url = "https://api.nucle.cloud/v1/event/delete";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<EventModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }
    }
}

