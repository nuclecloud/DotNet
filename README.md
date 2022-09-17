# [Nucle Cloud](https://nucle.cloud) .Net Library

In order to make life easier for you, we have created a Nucle Cloud .Net library that you can download and use.
This tool will allow you instant access to the Nucle Cloud API service in a .Net environment, you will be writing less lines of code and save a lot of time.

 
## Instalation 

  `dotnet add package nucle.cloud`  


## Content
First thing to do when using the library is to import it like bellow

 `using Nucle.Cloud;`

### User
- `Create(string projectId,string userName,string email,string password)`   
Create new user, return the user created (UserModel)
- `Login(string projectId,string email,string password )`   
Login a user, return (LoginResult)
- `RevokeToken(string userToken)`   
 Revoke a user token, return  (LoginResult)
- `SendResetPassword(string projectId,string email)`    
Send password reset email to email user
- `SendEmailConfirmation(string projectId,string email)`  
Send email confirmation to email user
- `Upgrade(strin guserToken,strin userName,string email,string password)`  
Upgrade anonymous to real user, return upgraded user  (UserModel)
- `GetById(string userToken,string userId)`  
Get user by id ,return user  (UserModel)
- `GetType(string userToken)`  
Get user type(REAL/ANONYMOUS/EXTERNALLOGIN), return type (string)
- `SetDisplayName(string userToken,string displayName)`  
S et user displayName, return user  (UserModel)
-`GetGeolocalizationData(string userToken)`  
Get user geolocalization data , return (GeolocalizationModel)
- `Delete(string userToken)`  
Delete user, return deleted user  (UserModel)
 

### Anonymous 

    

 - `Login(string projectId,string deviceId)`  
Login anonymous user, return (LoginResult)
 - `Create(string projectId,string deviceId)`  
Create anonymous user, return (LoginResult)
### External Login

   
- `Create(string projectId,string loginProvider,string providerKey,string providerDisplayName,string userEmail,string userName)`  
Create external login, return (UserModel) 
- `Login(string projectId,string loginProvider,string providerKey)`  
Login using external login, return (LoginResult)
- `Get(string userToken,string loginProvider, string providerKey)`  
Get external login, return (ExternalLoginModel)
- `Delete(string userToken,string loginProvider,string providerKey)`  
Delete external login, return deleted external login (ExternalLoginModel)

### Preset
 - `GetById(string userToken,string presetId)`  
Get preset by id, return (PresetModel)
 - `GetByName(string userToken,string presetName)`  
Get preset by name, return (PresetModel)

### Variable

- `Update(string userToken,string presetId,string value)`  
 Update variable, if it does not exists this will create a new variable with the value provided, return (VariableModel).  
- `Get(string userToken,string presetId)`  
 Get variable, return (VariableModel) 
- `Delete(string userToken,string presetId)`  
Delete variable, return deleted variable (VariableModel)
- `GetList(string userToken,string presetId,int skip,int take,orderType orderType,string searchValue)`  
 Get variables list,
 orderType is enum
 `enum orderType{HighToLow, LowToHigh, Newest,Oldest}`
 return (VariablesModel), 
 *VariablesModel:* has a list of  (VariableModel) and totalCount of variables without pagination applied
- `Count(string userToken,string presetId,string searchValue)`  
Count of variables without pagination applied

## Example

Create a new user and print its id. 
```
using Nucle.Cloud;

var projectId= "b943*************************c173";
var newUser = await User.Create(projectId, "ross88@gmail.com", "P@ssw0rd", "ross") ;
Console.WriteLine("New user id= " + newUser.id);
```

Login a user and print its token.
```
using Nucle.Cloud;

var projectId= "b943*************************c173";
var loginResult = await User.Login(projectId, "ross88@gmail.com", "P@ssw0rd");
Console.WriteLine("user Token= " + loginResult.userToken);
```
## GitHub 

You can always check the source code on [GitHub](https://github.com/nuclecloud/dotnet), report any bugs or contribute if you would like.
