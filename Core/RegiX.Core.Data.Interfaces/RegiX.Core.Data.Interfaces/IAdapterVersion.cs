namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public interface IAdapterVersion
    {
        string AdapterName { get; set; }
        string AdapterContract { get; set; }
        string AdapterAssembly { get; set; }
        string VersionOfAdapter { get; set; }
    }
}