# TechnoLogica Identity Server

Custom logo and icon should be provided in main project (wwwroot folder) with the following names:
* logo.png for application logo
* logoRight.png for application right image
* favicon.ico for the web page icon

# HTTPS
Identity Server should be accessed through HTTPS. If http is used the autnetication cookie cannot be set becaused it is marked as secure.

# HOST header in Apache
**ProxyPreserveHost On**

When enabled, this option will pass the Host: line from the incoming request to the proxied host, instead of the hostname specified in the `ProxyPass` line.

This option should normally be turned `Off`. It is mostly useful in special configurations like proxied mass name-based virtual hosting, where the original Host header needs to be evaluated by the backend server.

# CORS
CORS configuratiohn should be set also on client definitions:
```json
      {
        "Enabled": true,
        "ClientId": "angularlocalclient",
        "ClientName": "Local Anuglar Client",
        "RequirePkce": true,
        "RequireClientSecret": false,
        "RequireConsent": false,
        "AccessTokenType": 1,
        "AllowedGrantTypes": [ "authorization_code" ],
        "ClientSecrets": [
          {
            "Description": "Angular Client Application Secret",
            "Value": "###"
          }
        ],
        "AllowedScopes": [ "openid", "profile", "sampleapi" ],
        "RedirectUris": [ "http://localhost:4200/authorized", "http://localhost:4200/auth/login", "http://localhost:4200/silent-renew.html" ],
        "PostLogoutRedirectUris": [ "http://localhost:4200/" ],
        "AllowedCorsOrigins": [ "http://localhost:4200" ]
      },
```

# Distributed Cache
SQL Server based distributed cache is used if the following connection string is present in the configuration file:
Expected table name: DistributedCache
Exepcted schema name: dbo

# Migration from 3.x to 4.1
```sql
alter TABLE [dbo].[PersistedGrants]
add
    [SessionId] nvarchar(100) NULL,
    [Description] nvarchar(200) NULL,
    [ConsumedTime] datetime2 NULL;

alter TABLE [dbo].[DeviceCodes]
add [SessionId] nvarchar(100) NULL,
    [Description] nvarchar(200) NULL;
```
