namespace PortTesterClient.PortTesterServiceProxy
{
    using System;
    using System.ServiceModel;

    public partial class PortTesterServiceClient : IDisposable
    {
        void IDisposable.Dispose()
        {
            var success = false;

            try
            {
                if (this.State != CommunicationState.Faulted)
                {
                    this.Close();
                    success = true;
                }
            }
            finally
            {
                if (!success)
                {
                    this.Abort();
                }
            }
        }
    }
}