using System;
using MsFest_1.Account.Commands;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace MsFest_1.Account.CommandHandlers
{
    public class OpenAccountCommandHandler : CommandHandler<OpenAccountCommand>
    {
        private readonly IDomainRepository _domainRepository;

        public OpenAccountCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public override void Handle(OpenAccountCommand command)
        {
            var account = new Domain.Account(Guid.NewGuid());
            account.OpenFor(command.Name, command.Address);
            _domainRepository.Save(account);
        }
    }
}