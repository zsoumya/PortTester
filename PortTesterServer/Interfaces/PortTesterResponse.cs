namespace PortTesterServer.Interfaces
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = Constants.APP_NS)]
    public class PortTesterResponse
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ServerId { get; set; }
    }
}