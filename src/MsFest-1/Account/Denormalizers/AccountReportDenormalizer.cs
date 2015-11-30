using MsFest_1.Account.Events;
using MsFest_1.Account.Views;
using SimpleCqrs.Eventing;

namespace MsFest_1.Account.Denormalizers
{
    public class AccountReportDenormalizer : 
        IHandleDomainEvents<AccountCreatedEvent>,
        IHandleDomainEvents<AccountOpenedEvent>,
        IHandleDomainEvents<UserMovedToNewAddressEvent>
    {
        private readonly AccountReportTable _table;

        public AccountReportDenormalizer(AccountReportTable table)
        {
            _table = table;
        }

        public void Handle(AccountCreatedEvent domainEvent)
        {
            _table.OpenAccount(domainEvent.AggregateRootId);
        }

        public void Handle(AccountOpenedEvent domainEvent)
        {
            _table.SetUser(domainEvent.AggregateRootId, domainEvent.Name, domainEvent.Address);
        }

        public void Handle(UserMovedToNewAddressEvent domainEvent)
        {
            _table.ChangeAddress(domainEvent.AggregateRootId, domainEvent.Address);
        }
    }
}