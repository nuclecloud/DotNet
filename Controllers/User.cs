using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Nucle.Cloud
{
    public static class User
    {
        public static async Task<UserModel> Create(string projectId, string email,string password,string userName)
        {
            var model = new { email, password, userName };
            var url = "https://api.nucle.cloud/v1/user/create";
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
                return null;
            }
        }

        public static async Task<LoginResult> Login(string projectId, string email, string password)
        {
            var model = new { email, password };
            var url = "https://api.nucle.cloud/v1/user/login";
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

        public static async Task<LoginResult> RevokeToken(string userToken)
        {
            var url = "https://api.nucle.cloud/v1/user/revoketoken";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            StringContent httpContent = new StringContent("{}", System.Text.Encoding.UTF8
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

        public static async Task SendResetPassword(string projectId, string email)
        {
            var model = new { email };
            var url = "https://api.nucle.cloud/v1/user/passwordreset/send";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);

            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
         , "application/json");

            await client.PostAsync(url, httpContent);
        }

        public static async Task SendEmailConfirmation(string projectId, string email)
        {
            var model = new { email};
            var url = "https://api.nucle.cloud/v1/user/confirmemail/send";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("projectId", projectId);


            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8
         , "application/json");

            await client.PostAsync(url, httpContent);
        }

        public static async Task<UserModel> Upgrade(string userToken, string email, string password, string userName)
        {
            var model = new { email, password, userName };
            var url = "https://api.nucle.cloud/v1/user/upgrade";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

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

        public static async Task<UserModel> GetById(string userToken, string id )
        {
            var model = new { id };
            var url = "https://api.nucle.cloud/v1/user/get";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

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

        public static async Task<string> GetType(string userToken)
        {
            var url = "https://api.nucle.cloud/v1/user/get/type";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            StringContent httpContent = new StringContent("{ }", System.Text.Encoding.UTF8
    , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();


            if (response.IsSuccessStatusCode)
            {
                return jsonString;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }

        }

        public static async Task<UserModel> SetDisplayName(string userToken,string displayName)
        {
            var model = new { displayName };
            var url = "https://api.nucle.cloud/v1/user/displayname/set";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

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

        public static async Task<GeolocalizationModel> GetGeolocalizationData(string userToken)
        {
            var url = "https://api.nucle.cloud/v1/user/geolocalization/get";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            StringContent httpContent = new StringContent("{ }", System.Text.Encoding.UTF8
    , "application/json");
            var response = await client.PostAsync(url, httpContent);
            var jsonString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<GeolocalizationModel>(jsonString);
                return result;
            }
            else
            {
                var error = JsonConvert.DeserializeObject<ErrorModel>(jsonString);
                throw new Exception(error.errorMessage);
            }

        }

        public static async Task<UserModel> Delete(string userToken)
        {
            var url = "https://api.nucle.cloud/v1/user/delete";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("userToken", userToken);

            StringContent httpContent = new StringContent("{ }", System.Text.Encoding.UTF8
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
