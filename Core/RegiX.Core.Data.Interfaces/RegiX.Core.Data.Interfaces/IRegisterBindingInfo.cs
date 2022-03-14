namespace TechnoLogica.RegiX.Core.Data.Interfaces
{
    public interface IRegisterBindingInfo
    {
        string BindingType { get; set; }
        string BindingConfigName { get; set; }
        string Behavior { get; set; }
        string AdapterURL { get; set; }
        string ContractName { get; set; }
    }
}