using System;
using System.Collections;
using System.Collections.Generic;

namespace Nucle.Cloud
{

    public enum emailAction { EmailConfirmation, PasswordReset};
    [Serializable]
    public class UserModel
    {
        public string id;
        public string userName;
        public string displayName;
        public string email;
        public string creationDate;
        public string lastLogin;
        public string ip;
        public string city;
        public string region;
        public string country;
        public string country_code;
        public string latitude;
        public string longtitude;
        public string os;
    }
 
    [Serializable]
    public class LoginResult
    {
        public string userToken;
        public UserModel user;

        public LoginResult()
        {

        }
    }

  
}
