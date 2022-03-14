namespace TechnoLogica.RegiX.AdapterConsole.DataContracts.DTO
{
    public class ParamsValues
    {
        public ParamsValues()
        {
        }

        public ParamsValues(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}