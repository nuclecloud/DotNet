# [Nucle Cloud](https://nucle.cloud) .Net Library

In order to make life easier for you, we have created a Nucle Cloud .Net library that you can download and use.
This tool will allow you instant access to the Nucle Cloud API service in a .Net environment, you will be writing less lines of code and save a lot of time.

 
## Instalation 

  `dotnet add package nucle.cloud`  


## Content
First thing to do when using the library is to import it like bellow

 `using Nucle.Cloud;`

### User
- `Create(projectId,userName,email,password)`   
Create new user, return the user created (UserModel)
- `Login(projectId,email,password )`   
Login a user, return (LoginResult)
- `RevokeToken(userToken)`   
 Revoke a user token, return  (LoginResult)
- `SendResetPassword(projectId,email)`    
Send password reset email to email user
- `SendEmailConfirmation(projectId,email)`  
Send email confirmation to email user
- `Upgrade(userToken,userName,email,password)`  
Upgrade anonymous to real user, return upgraded user  (UserModel)
- `GetById(userToken,userId)`  
Get user by id ,return user  (UserModel)
- `GetType(userToken)`  
Get user type(REAL/ANONYMOUS/EXTERNALLOGIN), return type (string)
- `SetDisplayName(userToken,displayName)`  
S et user displayName, return user  (UserModel)
-`GetGeolocalizationData(userToken)`  
Get user geolocalization data , return (GeolocalizationModel)
- `Delete(userToken)`  
Delete user, return deleted user  (UserModel)
 

### Anonymous 

    

 - `Login(projectId,deviceId)`  
Login anonymous user, return (LoginResult)
 - `Create(projectId,deviceId)`  
Create anonymous user, return (LoginResult)
### External Login

   
- `Create(projectId,loginProvider,providerKey,providerDisplayName,userEmail,userName)`  
Create external login, return (UserModel) 
- `Login(projectId,loginProvider,providerKey)`  
Login using external login, return (LoginResult)
- `Get(userToken,loginProvider,providerKey)`  
Get external login, return (ExternalLoginModel)
- `Delete(userToken,loginProvider,providerKey)`  
Delete external login, return deleted external login (ExternalLoginModel)

### Preset
 - `GetById(userToken,presetId)`  
Get preset by id, return (PresetModel)
 - `GetByName(userToken,presetName)`  
Get preset by name, return (PresetModel)

### Variable

- `Update(userToken,presetId, value)`  
 Update variable, return (VariableModel)
- `Get(userToken,presetId)`  
 Get variable, return (VariableModel) 
- `Delete(userToken,presetId)`  
Delete variable, return deleted variable (VariableModel)
- `GetList(userToken,presetId,skip,take,orderType, searchValue)`  
 Get variables list, return (VariablesModel), 
 *VariablesModel:* has a list of  (VariableModel) and totalCount of variables without pagination applied
- `Count(userToken,presetId, searchValue)`  
Count of variables without pagination applied

## Example

Create a new user and print its id. 
```
using Nucle.Cloud;
 
var newUser = await User.Create("b943*************************c173", "ross88@gmail.com", "P@ssw0rd", "ross") ;
Console.WriteLine("New user id= " + newUser.id);
```

Login a user and print its token.
```
using Nucle.Cloud;

var loginResult = await User.Login("b943*************************c173", "ross88@gmail.com", "P@ssw0rd");
Console.WriteLine("user Token= " + loginResult.userToken);
```
## GitHub 

You can always check the source code on [GitHub](https://github.com/nuclecloud/dotnet), report any bugs or contribute if you would like.
