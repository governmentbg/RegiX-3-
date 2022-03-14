namespace RegiX.Info.DataContracts.DTO.ConsumerProfile
{
    public class ConsumerProfileOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
