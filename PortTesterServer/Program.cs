namespace PortTesterServer
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    internal class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost serviceHost = null;

            try
            {
                serviceHost = new ServiceHost(typeof(PortTesterService));
                serviceHost.Open();

                ShowInfo(serviceHost);
                Console.Out.WriteLine("Press X to stop server");
                while (true)
                {
                    if (Console.ReadKey(true).Key == ConsoleKey.X)
                    {
                        break;
                    }
                }

                CloseHost(serviceHost);
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception);
                Console.Error.WriteLine("Aborting host");
                serviceHost?.Abort();
            }
        }

        private static void CloseHost(ServiceHost host)
        {
            try
            {
                Console.Error.WriteLine("User interruption detected: Closing host");
                host.Close();
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception);
                Console.Error.WriteLine("Aborting host");
                host.Abort();
            }
        }

        public static void ShowInfo(ServiceHost serviceHost)
        {
            Console.Out.WriteLine("Service Name: {0}", serviceHost.Description.ServiceType);
            Console.Out.WriteLine("Endpoints:");

            foreach (ServiceEndpoint serviceEndpoint in serviceHost.Description.Endpoints)
            {
                Console.Out.WriteLine("+ {0} [{1}]", serviceEndpoint.Address, serviceEndpoint.Contract.ContractType);
            }

            Console.Out.WriteLine();
        }
    }
}
