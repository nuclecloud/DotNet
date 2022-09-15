using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nucle.Cloud;

namespace Nucle.Cloud
{
    public static class Preset
    {
        public static async Task<PresetModel> GetById(string userToken, string presetId)
        {

            var model = new {presetId };
            var url = "https://api.nucle.cloud/v1/preset/get/id";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");

            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<PresetModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<PresetModel> GetByName(string userToken,string presetName)
        {
        
            var model = new {presetName };
            var url = "https://api.nucle.cloud/v1/preset/get/name";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");

            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<PresetModel>(jsonString);
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
