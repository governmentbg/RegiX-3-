# RegiX.ZADSAdapter

Адаптерът работи с Informix база данни. 
За целта реферира RegiX.InformixConnection проекта. 
В него е заложен IBM.Data.Informix.dll. 
Версията на този dll е МНОГО ВАЖНА за работоспособността на адаптера. 
Към момента е 4.0.540.1, за да работи с Informix Client 4.50 (IBM® Informix® ClientSDKV 4.50) # 64bit

Важно е dll-a в инсталационната директория на Informix Client-a (C:\Program Files\IBM Informix Client-SDK\bin\netf40) и тази в 
RegiX.InformixConnection проекта да е една и съща! В противен случай възниква следната грешка:

System.TypeInitializationException
IBM.Data.Informix
The type initializer for 'IBM.Data.Informix.IfxConnection' threw an exception.
   at IBM.Data.Informix.IfxConnection..ctor(String connectionString)
   at TechnoLogica.RegiX.ZADSAdapter.AdapterService.ZADSAdapter.GetRegistrationInfo(RegistrationInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
===========================
System.BadImageFormatException
IBM.Data.Informix
An attempt was made to load a program with an incorrect format. (Exception from HRESULT: 0x8007000B)
   at IBM.Data.Common.UnsafeNativeMethods.Ifx32.SQLAllocHandle(Int16 HandleType, IntPtr InputHandle, IntPtr& OutputHandle)
   at IBM.Data.Informix.IfxConnPoolManager..ctor()
   at IBM.Data.Informix.IfxConnection..cctor()
===========================

За да работи със 64bit клиент и dll от такъв, е нужно в IIS -> ApllicationPools -> <AppPoolName> -> AdvancedSettings -> Enable 32-bit Applications да е False! 
За 32 битов клиент и dll от такъв, стойността трябва да е True. 

!! RegiX.ZADSAdapter.nuspec - там е заложено       <dependency id="RegiX.InformixConnection" version="1.0.33"/>
При повдигане на версията на RegiX.InformixConnection проекта, освен Update на NuGet-а в адаптера, е нужно да се повиши и версията на 
dependency-то, иначе AzureDevOps не се усеща и не взима последната версия.

ВАЖНО! 
При инсталация на Informix Клиент локално на наши TL Машини (служебни компютри), първо трябва да се пусне remove-restr.reg файлчето от админите, иначе
не се инсталират GLS пакетите (Global Language Support) и възниква грешка:

IBM.Data.Informix.IfxException
IBM.Data.Informix
ERROR [HY000] [Informix .NET provider][Informix]Unable to load locale categories.
   at IBM.Data.Informix.DBCWrapper..ctor(IfxConnection connection)
   at IBM.Data.Informix.IfxConnectionPool.IfxConnPoolNode..ctor(IfxConnection connection)
   at IBM.Data.Informix.IfxConnectionPool.OpenNewConnection(IfxConnection connection, ConnectionPoolType ConnPoolType)
   at IBM.Data.Informix.IfxConnectionPool.Open(IfxConnection connection)
   at IBM.Data.Informix.IfxConnPoolManager.Open(IfxConnection connection)
   at IBM.Data.Informix.IfxConnection.Open()
   at TechnoLogica.RegiX.ZADSAdapter.AdapterService.ZADSAdapter.GetRegistrationInfo(RegistrationInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)
===========================
IBM.Data.Informix.IfxException
IBM.Data.Informix
ERROR [HY000] [Informix .NET provider][Informix]Unable to load locale categories.
   at IBM.Data.Informix.DBCWrapper..ctor(IfxConnection connection)
   at IBM.Data.Informix.IfxConnectionPool.IfxConnPoolNode..ctor(IfxConnection connection)
   at IBM.Data.Informix.IfxConnectionPool.OpenNewConnection(IfxConnection connection, ConnectionPoolType ConnPoolType)
   at IBM.Data.Informix.IfxConnectionPool.Open(IfxConnection connection)
   at IBM.Data.Informix.IfxConnPoolManager.Open(IfxConnection connection)
   at IBM.Data.Informix.IfxConnection.Open()
   at TechnoLogica.RegiX.ZADSAdapter.AdapterService.ZADSAdapter.GetRegistrationInfo(RegistrationInfoRequestType argument, AccessMatrix accessMatrix, AdapterAdditionalParameters aditionalParameters)


При инсталация в АМ, да се провери за наличие на GLS папка в инсталационната директория на Informix! 

Не е нужно да се указват INFORMIXDIR / CLIENT_LOCALE / DATABASE_LOCALE като Environment variables на ОС. След инсталацията директорията се сетва в PATH. 


! Проверка за повече от един клиент с различен bitness!

Search -> ODBC DataSources (32-bit) и (64-bit)
В таб-а Drivers се вижда Informix Driver-a (IBM INFORMIX ODBC DRIVER (XXbit)) и версията му.
Не трябва да имаме едновременно инсталиран 32 и 64 битов клиент. 
Ако имаме такъв казус, деинсталираме ненужния клиент и оставяме само този, с който искаме да работим (32 или 64bit)