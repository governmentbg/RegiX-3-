using System;

namespace RegiX.Info.API.DTOs.ConsumerProfileUsers
{
    public class ConsumerProfileUsersOutDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
    }
}