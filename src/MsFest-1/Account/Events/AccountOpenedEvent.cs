using System;
using SimpleCqrs.Eventing;

namespace MsFest_1.Account.Events
{
    [Serializable]
    public class AccountOpenedEvent : DomainEvent
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public AccountOpenedEvent(Guid accountId, string name, string address)
        {
            AccountId = accountId;
            Name = name;
            Address = address;
        }

        public AccountOpenedEvent()
        {
            
        }
    }
}