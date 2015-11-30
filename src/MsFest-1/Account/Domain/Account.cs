using System;
using MsFest_1.Account.Events;
using SimpleCqrs.Domain;

namespace MsFest_1.Account.Domain
{
    public class Account : AggregateRoot
    {
        string name;
        string address;

        public Account(Guid id)
        {
            Apply(new AccountCreatedEvent() { AggregateRootId = id });
        }

        public Account()
        {
        }

        void OnAccountCreated(AccountCreatedEvent @event)
        {
            Id = @event.AggregateRootId;
        }

        public void OpenFor(string name, string address)
        {
            Apply(new AccountOpenedEvent(Id, name, address));
        }

        void OnAccountOpened(AccountOpenedEvent @event)
        {
            name = @event.Name;
            address = @event.Address;
        }

        public void MoveUserToAddress(string address)
        {
            Apply(new UserMovedToNewAddressEvent(Id, address));
        }
    }
}