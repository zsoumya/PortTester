namespace PortTesterServer.Interfaces
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [DataContract(Namespace = Constants.APP_NS)]
    public class PortTesterRequest
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ClientId { get; set; }
    }
}