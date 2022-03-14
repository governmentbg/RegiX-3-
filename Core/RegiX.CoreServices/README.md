# RegiX Core Services

# [Auto increment assembly version](http://thinkofdev.com/auto-increase-project-version-number-in-visual-studio/)
И ето [тук](https://stackoverflow.com/questions/356543/can-i-automatically-increment-the-file-build-version-when-using-visual-studio)

Оставя се само първият ред:
```csharp
[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.0.*")]
```
Вторият ред се изтрива:

~~[assembly: AssemblyFileVersion("1.0.*")]~~

# Копиране в output
Следните редове в proj файла са необходизи за правилното копиране на XML-и, XSD-та и XSLT-та в output директорията
```xml
  <ItemGroup>
    <Content Include="XMLMetaData\*\*.xml">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <Content Include="XMLSamples\*\*.xml">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <Content Include="XMLSchemas\*\Transformations\*.xslt">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
    <Content Include="XMLSchemas\*\*.xsd">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
```