namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public interface IAdapterInfo
    {
        string AdapterServiceContract { get; set; }
        string APIServiceContract { get; set; }
        string APIServiceOperation { get; set; }
    }
}