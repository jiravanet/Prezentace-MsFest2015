using SimpleCqrs.Commanding;

namespace MsFest_1.Account.Commands
{
    public class OpenAccountCommand : ICommand
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public OpenAccountCommand(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}