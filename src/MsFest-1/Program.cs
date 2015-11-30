using System;
using System.Linq;
using MsFest_1.Account.Commands;
using MsFest_1.Account.Views;
using SimpleCqrs.Commanding;
using SimpleCqrs.Eventing;
using SimpleCqrs.EventStore.SqlServer;
using SimpleCqrs.EventStore.SqlServer.Serializers;
using SimpleCqrs.Unity;

namespace MsFest_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var runtime = new DemoRuntime();

            runtime.Start();
            var accountTable = new AccountReportTable();
            runtime.ServiceLocator.Register(accountTable);

            var commandBus = runtime.ServiceLocator.Resolve<ICommandBus>();

            var command = new OpenAccountCommand("Petr", "Kolbenova 43");


            commandBus.Send(command);

            PrettyPrint(accountTable);
            var id = accountTable.First().Id;
            var moveCommand = new MoveUserToAddressCommand(id, "Dankova 45");
            commandBus.Send(moveCommand);

            PrettyPrint(accountTable);

            runtime.Shutdown();

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        private static void PrettyPrint(AccountReportTable accountTable)
        {
            foreach (var row in accountTable)
            {
                Console.WriteLine($"Account {row.Id} for {row.Name} at {row.Address}");
            }
        }

        public class DemoRuntime : SimpleCqrs.SimpleCqrsRuntime<UnityServiceLocator>
        {
            protected override IEventStore GetEventStore(SimpleCqrs.IServiceLocator serviceLocator)
            {
                var configuration = new SqlServerConfiguration("Server=(local);Database=demo_event_store;Trusted_Connection=True;");
                return new SqlServerEventStore(configuration, new JsonDomainEventSerializer());
            }
        }
    }
}
