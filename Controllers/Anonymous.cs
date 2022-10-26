using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Nucle.Cloud
{
    public static class Anonymous
    {

        /// <summary>
        /// Create an anonymous user
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="deviceId">Device id</param>
        /// <returns>User object</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<UserModel> Create(string projectId,string deviceId, string displayName = null)
        {
            var model = new { deviceId = deviceId , displayName = displayName };
            var url = "https://api.nucle.cloud/v1/user/anonymous/create";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }
        }
        /// <summary>
        /// Authenticate an anonymous user
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <param name="deviceId">Device id</param>
        /// <returns>UserToken and the user object</returns>
        /// <exception cref="Exception"></exception>

        public static async Task<LoginResult> Login(string projectId, string deviceId)
        {
            var model = new { deviceId = deviceId };
            var url = "https://api.nucle.cloud/v1/user/anonymous/login";
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
        /// <summary>
        /// Get an anonymous user.
        /// </summary>
        /// <param name="projectId"> Project id </param>
        /// <param name="deviceId"> Device id</param>
        /// <returns>User object</returns>
        /// <exception cref="Exception"></exception>

        public static async Task<UserModel> Get(string projectId, string deviceId)
        {
            var model = new { deviceId = deviceId };
            var url = "https://api.nucle.cloud/v1/user/anonymous/get";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
                , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<UserModel>(jsonString);
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
