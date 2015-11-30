using System;
using SimpleCqrs.Eventing;

namespace MsFest_1.Account.Events
{
    [Serializable]
    public class AccountCreatedEvent : DomainEvent
    {
    }
}