# RegiX.Info.API
## Referenced packages
* RegiX.Adapters.Common
* RegiX.FirebirdSqlAdapterService
* RegiX.MySqlAdapterService
* RegiX.NpgsqlAdapterService
* RegiX.OracleAdapterService
* RegiX.SQLServerAdapterService
* RegiX.WebServiceAdapterService
* RegiX.InformixAdapterService

```powersrhell
Install-Package RegiX.Adapters.Common -Version 1.0.16 -IgnoreDependencies
Install-Package RegiX.FirebirdSqlAdapterService -Version 1.0.1 -IgnoreDependencies
Install-Package RegiX.MySqlAdapterService -Version 1.0.1 -IgnoreDependencies
Install-Package RegiX.NpgsqlAdapterService -Version 1.0.2 -IgnoreDependencies
Install-Package RegiX.OracleAdapterService -Version 1.0.2 -IgnoreDependencies
Install-Package RegiX.SQLServerAdapterService -Version 1.0.1 -IgnoreDependencies
Install-Package RegiX.WebServiceAdapterService -Version 1.0.2 -IgnoreDependencies
Install-Package RegiX.InformixAdapterService -Version 1.0.3 -IgnoreDependencies
```

## Oracle

Install-Package RegiX.ASPFosterParentsAdapter -IgnoreDependencies
Install-Package RegiX.ASPSocialAdapter -IgnoreDependencies
Install-Package RegiX.AVTRAdapter -IgnoreDependencies
Install-Package RegiX.AZJobsAdapter -IgnoreDependencies
Install-Package RegiX.KzldAdministratorsAdapter -IgnoreDependencies
Install-Package RegiX.KzldDeniedAdministratorsAdapter -IgnoreDependencies
Install-Package RegiX.KzldExemptAdministratorsAdapter -IgnoreDependencies
Install-Package RegiX.MVRTouristRegisterAdapter -IgnoreDependencies
Install-Package RegiX.NHIFAdapter -IgnoreDependencies
Install-Package RegiX.PropertyRegAdapter -IgnoreDependencies

# Scaffold DB Context
```powershell
Scaffold-DbContext "Server=regix2-sql.regix.tlogica.com;initial catalog=regix;persist security info=True;user id=;password=;MultipleActiveResultSets=True;App=EntityFramework" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables CONSUMER_PROFILES,CONSUMER_PROFILE_STATUS,CONSUMER_PROFILE_USERS,CONSUMER_SYSTEMS,CONSUMER_SYSTEM_CERTIFICATES,CONSUMER_ACCESS_REQUESTS,CONSUMER_REQUEST_ROLES,CONSUMER_REQUEST_ELEMENTS,CONSUMER_REQUEST_OPERATIONS,CONSUMER_ROLES,REGISTER_OBJECT_ELEMENTS,CERTIFICATE_ELEMENT_ACCESS,CERTIFICATE_OPERATION_ACCESS,CERTIFICATE_CONSUMER_ROLE,CONSUMER_CERTIFICATES,API_SERVICE_CONSUMERS, ADAPTER_OPERATIONS, ADMINISTRATIONS, CONSUMER_REQUESTS, CONSUMER_REQUEST_STATUS, REGISTER_ADAPTERS, REGISTER_OBJECTS, REGISTERS  -ContextDir Models1 -Context RegiXContext1
```