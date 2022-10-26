# [Nucle Cloud](https://nucle.cloud) .Net Library

In order to make life easier for you, we have created a Nucle Cloud .Net library that you can download and use.
This tool will allow you instant access to the Nucle Cloud API service in a .Net environment, you will be writing less lines of code and save a lot of time.

 
## Instalation 

  `dotnet add package nucle.cloud`  


## Content
First thing to do when using the library is to import it like bellow

 `using Nucle.Cloud;`

### User
- `async Task<UserModel> Create(string projectId,string userName,string email,string password)`   
Create new user, return the user created.  
- `async Task<LoginResult> LoginWithEmail(string projectId,string email,string password )`   
Login a user with email.
- `async Task<LoginResult> LoginWithUserName(string projectId,string userName,string password )`   
Login a user with username.
- `async Task<LoginResult >RevokeToken(string userToken)`   
Revoke a user token.
- `SendEmail(string projectId,string email,emailAction emailAction)`    
Send a user an email to either confirm his email or to reset his password.
- `async Task<UserModel> Upgrade(string userToken,strin userName,string email,string password)`  
Upgrade anonymous to real user, return upgraded user.  
- `async Task<UserModel> GetById(string userToken,string userId)`  
Get user by id ,return user.  
- `async Task<string> GetType(string userToken)`  
Get user type(REAL/ANONYMOUS/EXTERNALLOGIN).
- `async Task<UserModel> SetDisplayName(string userToken,string displayName)`  
S et user displayName, return user.    
- `async Task<GeolocalisationModel> GetGeolocalisationData(string userToken)`  
Get user geolocalisation data.  
- `async Task<UserModel> Delete(string userToken)`  
Delete user, return deleted user.  
 

### Anonymous 

 - `async Task<UserModel> Create(string projectId,string deviceId)`  
Create an anonymous user.
 - `async Task<LoginResult> Login(string projectId,string deviceId)`  
Authenticate anonymous user.
 - `async Task<UserModel> Get(string projectId,string deviceId)`  
Get an anonymous user, return null if no anonymous user was found with the same device id.  

### External Login

   
- `async Task<UserModel> Create(string projectId,string loginProvider,string providerKey,string providerDisplayName,string userEmail,string userName)`  
Create external login.  
- `async Task<LoginResult> Login(string projectId,string loginProvider,string providerKey)`  
Login using external login.  
- `async Task<ExternalLoginModel> Get(string userToken,string loginProvider, string providerKey)`  
Get external login.  
- `async Task<ExternalLoginModel> Delete(string userToken,string loginProvider,string providerKey)`  
Delete external login, return deleted external login.  

### Preset
 - `async Task<PresetModel> GetById(string userToken,string presetId)`  
Get preset by id.  
 - `async Task<PresetModel> GetByName(string userToken,string presetName)`  
Get preset by name.  

### Variable

- `async Task<VariableModel> Update(string userToken,string presetId,string value)`  
 Update variable, if it does not exists this will create a new variable with the value provided.  
- `async Task<VariableModel> Get(string userToken,string presetId)`  
 Get variable.    
- `async Task<VariableModel> Delete(string userToken,string presetId)`  
Delete variable, return deleted variable  
- `async Task<VariablesModel> GetList(string userToken,string presetId,int skip,int take,orderType orderType,string searchValue)`  
 Get variables list,   
 *orderType:* (argument) enum  HighToLow=0, LowToHigh=1, Newest=2, Oldest=3.   
 *VariablesModel:* (return type )an object that contains a list of (VariableModel) and totalCount of variables without pagination applied.   
- `async Task<int> Count(string userToken,string presetId,string searchValue)`  
 Get the count of variables without pagination applied.  

## Example

Create a new user and print its id.   
Project Id to get from [Nucle.cloud](https://nucle.cloud) dashboard.   
```
using Nucle.Cloud;

var projectId= "b943*************************c173";
var newUser = await User.Create(projectId, "ross88@gmail.com", "P@ssw0rd", "ross") ;
Console.WriteLine("New user id= " + newUser.id);
```

Login a user and print its token.   
Project Id to get from [Nucle.cloud](https://nucle.cloud) dashboard.   
```
using Nucle.Cloud;

var projectId= "b943*************************c173";
var loginResult = await User.LoginWithEmail(projectId, "ross88@gmail.com", "P@ssw0rd");
Console.WriteLine("user Token= " + loginResult.userToken);
```
## GitHub 

You can always check the source code on [GitHub](https://github.com/nuclecloud/dotnet), report any bugs or contribute if you would like.
