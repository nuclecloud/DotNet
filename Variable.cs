using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nucle.Cloud;

namespace Nucle.Cloud
{
    public static class Variable
    {
        public static async Task<VariableModel> Update(string userToken,string presetId, string value)
        {
            var model = new { presetId, value };
            var url = "https://api.nucle.cloud/v1/variable/update";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<VariableModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<VariableModel> Get(string userToken, string presetId)
        {
            var model = new { presetId };
            var url = "https://api.nucle.cloud/v1/variable/get";
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");

            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<VariableModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<VariablesModel> GetList(string userToken, string presetId, string skip, string take, string orderType, string search)
        {
            var model = new { presetId, skip, take, orderType, search };
            var url = "https://api.nucle.cloud/v1/variable/list";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<VariablesModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }

        }

        public static async Task<VariableModel> Delete( string userToken, string presetId)
        {
            var model = new { presetId };
            var url = "https://api.nucle.cloud/v1/variable/delete";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                     , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<VariableModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<int> Count( string userToken, string presetId, string searchValue)
        {
            var model = new { presetId, searchValue };
            var url = "https://api.nucle.cloud/v1/variable/count";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                     , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<int>(jsonString);
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
