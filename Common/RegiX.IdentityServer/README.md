
Scaffold-DbContext "Server=regix2-sql.regix.tlogica.com;initial catalog=regix2ClientDevMultitenant;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework"  Microsoft.EntityFrameworkCore.SqlServer  -t USERS, USERS_TO_ROLES, LOCAL_USERS, FEDERATION_USERS -f

## Example configuration for SigningCredential
```json
  "SigningCredential": {
    "Platfrom": "Windows",
    "CertificateStoreName": "My",
    "CertificateStoreLocation": "LocalMachine",
    "CertificateX509FindType": "FindByThumbprint",
    "CertificateFindValue": ""
  },
  "SigningCredential": {
    "Platfrom": "Linux",
    "CertificateFileName": "dmitev-nb.subca.pfx",
    "CertificatePassword": "asdf"
  },
```

Scaffold-DbContext "Server=regix2-sql.regix.tlogica.com;initial catalog=regix;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework"  Microsoft.EntityFrameworkCore.SqlServer  -t CONSUMER_PROFILES,CONSUMER_PROFILE_STATUS, CONSUMER_PROFILE_USERS -f -ContextDir Context -ContextNamespace RegiX.IdentityServer.ConsumerProfileCredentials.Context