# EAuth
Представлява имплементация на EAuth интеграция

## Използване
EAtuh middlewear-а трябва да бъде регистриран по време на конфигурация на услугите в `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
   // ...
    services.AddAuthentication().AddEAuth(
        opt =>
        {
            opt.InformationSystemName = // Име на ифнормационната система, най-добре взета от конфигурация;
            opt.CallbackPath = // Адрес за callback (например "/EAuthAuthenticate");
            opt.RedirectConsumerServiceURL = // Адрес предоставян на EAuth за callback (например "https://localhost/EAuthAuthenticate" за локален тест в рамките на Identity Server);

            opt.ClientSystemCertificate = // Сертификат използван за подписване на SAML заявката.

            opt.EAuthSystemCertificate = // Сертификат, срещу когото трябва да проверим върнатия SAML отговор. Би трябвало да е bgEgovEAuthenticatorSigning.cer
        }
    );
    // ...
}
``