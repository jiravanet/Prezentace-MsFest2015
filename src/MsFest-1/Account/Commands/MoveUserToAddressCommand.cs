using System;
using SimpleCqrs.Commanding;

namespace MsFest_1.Account.Commands
{
    public class MoveUserToAddressCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

        public MoveUserToAddressCommand(Guid id, string address)
        {
            Id = id;
            Address = address;
        }
    }
}