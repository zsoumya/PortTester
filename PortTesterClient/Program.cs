namespace PortTesterClient
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;

    using PortTesterServiceProxy;

    internal class Program
    {
        private static readonly string ClientId = Dns.GetHostName();

        private static void Main(string[] args)
        {
            long counter = 0;
            long runCount = GetRunCount(args);

            while (true)
            {
                counter++;
                if (runCount != -1 && counter > runCount)
                {
                    break;
                }

                using (var client = new PortTesterServiceClient())
                {
                    try
                    {
                        Console.Out.WriteLine($"Pinging {client.Endpoint.Address}");

                        PortTesterResponse response = client.Ping(new PortTesterRequest
                        {
                            Message = "Hello from client",
                            ClientId = ClientId
                        });

                        string message = $"** [{DateTime.Now:yyyyMMddTHHmmss}] [Sender: {response.ServerId}] {response.Message}{Environment.NewLine}";
                        Console.Out.WriteLine(message);
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine($"Ping Error: {exception.Message}");
                    }
                }

                Thread.Sleep(500);
            }
        }

        private static long GetRunCount(IList<string> args)
        {
            return args?.Count > 0 && long.TryParse(args[0], out long count) ? count : -1;
        }
    }
}