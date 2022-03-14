# RegiX.DaeuReportsAdapter


Описание на данните съхранявани в ElastiSearch за целите на извършване на справки за гражданите

|Поле|Тип|Описание|
|:-----|:-----|:-----|
|startTime | Дата | Начало на извършване на заявката|
|endTime | Дата | Край на извършване на заявката|
|apiServiceCallId | Число | Пореден номер на заявката|
|request | Текст | Текст на заявката|
|identifier | Текст | Идентификатор извлечен от заявката|
|hidden | Булев тип | Дали конкретният запис да се показва в приложението за граждани|
|identifierType | Текст | Тип на идентификатор|
|apiServiceOperationID | Число | Идентификатор на операцията|
|consumer | Текст | Консуматор|
|consumerAdministration | Текст | Администрация на консуматор|
|reportName | Текст | Име на операция|
|producer | Текст | Регистър предоставящ операцията|
|producerAdministration | Текст | Администрация предоставяща операцията|
|consumerCertificateID | Число | Идентификатор на сертификат на консуматор|
|callContext | Текст | Контекст на заявката|
|contextAdministrationName | Текст | Име на администрация от контекста|
|contextAdministrationOID | Текст | OID на администрация от контекста|
|contextEmployeeAdditionalIdentifier | Текст | Идентификатор на служител извършващ операцията|
|contextEmployeeNames | Текст | Имена на служител извършващ операцията|
|contextEmployeePosition | Текст | Позиция на служител|
|contextEmployeeIdentifier | Текст | Идентификатор на служител|
|contextLawReason | Текст | Правно основание|
|contextResponsibleNames | Текст | Имена на отговорник|
|contextServiceURI | Текст | URI на услуга във връзка, с която се изпълнява операцията|
|contextServiceType | Текст | Тип на услуга във връзка, с която се изпълнява операцията|
|eIDToken | Текст | EID token|
|oIDToken | Текст | OID token|
|clientIPAddres | Текст | IP адрес на консуматор|
|resultReady | Булев тип | Дали резултата е готов|
|resultReturned | Булев тип | Дали резултата е предоставен на консуматора|
|hasError | Булев тип | Дали е възникнала грешка|
|errorLogTime | Дата | Време на възникване на грешка|
|errorMessage | Текст | Съобщение за грешка|
|errorContent | Текст | Съдържание на грешка|
|requestDuration | Число | Продължителност на справката|
|fullContractName | Текст | Пълно име на операцията|
|consumerOID | Текст | OID на консуматор|