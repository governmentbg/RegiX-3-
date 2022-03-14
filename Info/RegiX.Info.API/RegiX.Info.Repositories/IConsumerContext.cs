using System;
using System.Collections.Generic;
using System.Text;

namespace RegiX.Info.Repositories
{
    public interface IConsumerContext
    { 
        public int? UserId { get; }

        public decimal? ConsumerProfileID { get; }
    }
}
