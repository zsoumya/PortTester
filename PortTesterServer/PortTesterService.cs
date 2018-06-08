namespace PortTesterServer
{
    using System;
    using System.ServiceModel;

    using Interfaces;

    [ServiceBehavior(ConfigurationName = Constants.APP_SVC_NAME, InstanceContextMode = InstanceContextMode.PerCall)]
    public class PortTesterService : IPortTesterService
    {
        private readonly string ServerId = $"PortTesterServer:{Guid.NewGuid()}";

        public PortTesterResponse Ping(PortTesterRequest request)
        {
            string message = $"## [{DateTime.Now:yyyyMMddTHHmmss}] [Sender: {request.ClientId}] {request.Message}{Environment.NewLine}";
            Console.Out.WriteLine(message);
            return new PortTesterResponse()
            {
                ServerId = this.ServerId,
                Message = "Hello from server"
            };
        }
    }
}