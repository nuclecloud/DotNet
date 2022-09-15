using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nucle.Cloud;

namespace Nucle.Cloud
{
    public static class ExternalLogin
    {
        public static async Task<LoginResult> Create(string projectId,string loginProvider, string providerDisplayName, string providerKey, string userEmail, string userName)
        {
            var model = new { loginProvider, providerDisplayName, providerKey, userEmail, userName };
            var url = "https://api.nucle.cloud/v1/user/externallogin/create";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<LoginResult>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<LoginResult> Login(string projectId,string loginProvider, string providerKey)
        {
            var model = new { loginProvider, providerKey };
            var url = "https://api.nucle.cloud/v1/user/externallogin/login";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<LoginResult>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<ExternalLoginModel> Get(string userToken, string loginProvider, string providerKey)
        {
            var model = new { loginProvider, providerKey };
            var url = "https://api.nucle.cloud/v1/user/externallogin/get";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                     , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ExternalLoginModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }

        public static async Task<ExternalLoginModel> Delete(string userToken,string loginProvider, string providerKey)
        {
            var model = new { loginProvider, providerKey };
            var url = "https://api.nucle.cloud/v1/user/externallogin/delete";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            StringContent httpContent = new StringContent("{ }", System.Text.Encoding.UTF8
                     , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ExternalLoginModel>(jsonString);
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
