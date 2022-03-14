1. След прегенериране на класовете за GetActualStateV2 и на GetActualStateV3 и GetBranchOffice, при промяна в TRSubdeedsCommon трябва ръчно:
- да се зададе типа на RecordData да е XmlElement вместо object
- да се сложи атрибут на RecordData: XmlAnyElement
2. Преди публикуване на схемите в Info приложението, трябва типа на MainFieldIdent да се промени от string на FieldCodes.
Целта е консуматорите да са наясно за кодировката на стойността в полето, а същевременно адаптера да работи със string.