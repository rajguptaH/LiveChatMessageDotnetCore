# LiveChatMessageDotnetCore
 Live Chat & Call Web App With Login/Signup Using CometChat

 I have used Widget's in this WebApp
 This project is based on Dotnet Core 7.0
 # clone this project 
 ```cmd
 git clone https://github.com/rajguptaH/LiveChatMessageDotnetCore.git
```
# Modify Connection strings in AppSettings.Json
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=serverName;Database=databasename; User ID=username;Password=password;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```
# Now Run Migrations 
```cmd
cd path/to/LiveCallMessageDotnetCore.Data
dotnet ef database update
```
# Now Make account on [ComentChat](https://www.cometchat.com/)
# After That Create a Widget There and Open Views/Home/Index.cshtml and put your cometchat credentials
```cshtml
<script>
.........................
    "appID": "appId",
    "appRegion": "app-region",
    "authKey": "authkey"
............................

.................................
      ..........................
               ...............
                "widgetID": "widgetid"
</script>

```
Yo. Enjoy.....
[Raj Narayan Gupta](https://rajnarayangupta.netlify.app)
