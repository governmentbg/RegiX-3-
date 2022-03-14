namespace RegiX.Info.Repositories
{
    public class ConsumerContext : IConsumerContext
    {
        public int? UserId { get; }
        public decimal? ConsumerProfileID { get; }
    }
}