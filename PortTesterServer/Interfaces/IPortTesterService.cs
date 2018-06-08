namespace PortTesterServer.Interfaces
{
    using System.ServiceModel;

    [ServiceContract(Namespace = Constants.APP_NS, ConfigurationName = Constants.APP_SVC_NAME)]
    public interface IPortTesterService
    {
        [OperationContract(Action = Constants.APP_SVC_NAME + ":Ping", ReplyAction = Constants.APP_SVC_NAME + ":PingResponse")]
        PortTesterResponse Ping(PortTesterRequest request);
    }
}