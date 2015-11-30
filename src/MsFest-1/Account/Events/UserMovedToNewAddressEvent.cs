using System;
using SimpleCqrs.Eventing;

namespace MsFest_1.Account.Events
{
    [Serializable]
    public class UserMovedToNewAddressEvent : DomainEvent
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

        public UserMovedToNewAddressEvent(Guid id, string address)
        {
            Id = id;
            Address = address;
        }

        public UserMovedToNewAddressEvent()
        {
            
        }
    }
}