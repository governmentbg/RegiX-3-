# RegiX.ZADSAdapter

��������� ������ � Informix ���� �����. 
�� ����� �������� RegiX.InformixConnection �������. 
� ���� � ������� IBM.Data.Informix.dll. 
�������� �� ���� dll � ����� ����� �� ������������������ �� ��������. 
��� ������� � 4.0.540.1, �� �� ������ � Informix Client 4.50 (IBM� Informix� ClientSDKV 4.50) # 64bit

����� � dll-a � ��������������� ���������� �� Informix Client-a (C:\Program Files\IBM Informix Client-SDK\bin\netf40) � ���� � 
RegiX.InformixConnection ������� �� � ���� � ����! � �������� ������ �������� �������� ������:

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

�� �� ������ ��� 64bit ������ � dll �� �����, � ����� � IIS -> ApllicationPools -> <AppPoolName> -> AdvancedSettings -> Enable 32-bit Applications �� � False! 
�� 32 ����� ������ � dll �� �����, ���������� ������ �� � True. 

!! RegiX.ZADSAdapter.nuspec - ��� � ��������       <dependency id="RegiX.InformixConnection" version="1.0.33"/>
��� ��������� �� �������� �� RegiX.InformixConnection �������, ����� Update �� NuGet-� � ��������, � ����� �� �� ������ � �������� �� 
dependency-��, ����� AzureDevOps �� �� ����� � �� ����� ���������� ������.

�����! 
��� ���������� �� Informix ������ ������� �� ���� TL ������ (�������� ��������), ����� ������ �� �� ����� remove-restr.reg �������� �� ��������, �����
�� �� ���������� GLS �������� (Global Language Support) � �������� ������:

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


��� ���������� � ��, �� �� ������� �� ������� �� GLS ����� � ��������������� ���������� �� Informix! 

�� � ����� �� �� ������� INFORMIXDIR / CLIENT_LOCALE / DATABASE_LOCALE ���� Environment variables �� ��. ���� ������������ ������������ �� ����� � PATH. 


! �������� �� ������ �� ���� ������ � �������� bitness!

Search -> ODBC DataSources (32-bit) � (64-bit)
� ���-� Drivers �� ����� Informix Driver-a (IBM INFORMIX ODBC DRIVER (XXbit)) � �������� ��.
�� ������ �� ����� ������������ ���������� 32 � 64 ����� ������. 
��� ����� ����� �����, ������������� �������� ������ � �������� ���� ����, � ����� ������ �� ������� (32 ��� 64bit)