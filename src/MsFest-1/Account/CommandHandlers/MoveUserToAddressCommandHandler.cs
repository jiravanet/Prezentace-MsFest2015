using MsFest_1.Account.Commands;
using SimpleCqrs.Commanding;
using SimpleCqrs.Domain;

namespace MsFest_1.Account.CommandHandlers
{
    public class MoveUserToAddressCommandHandler : CommandHandler<MoveUserToAddressCommand>
    {
        private readonly IDomainRepository _domainRepository;

        public MoveUserToAddressCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public override void Handle(MoveUserToAddressCommand command)
        {
            var account = _domainRepository.GetById<Domain.Account>(command.Id);
            account.MoveUserToAddress(command.Address);
            _domainRepository.Save(account);
        }
    }
}