using System;
using Microsoft.Commerce.Broker;
using Microsoft.Commerce.Contracts;
using Microsoft.Commerce.Contracts.Messages;

namespace CSUtilities.Debugging.ActualFault
{
    public class ActualExceptionThrowingOperationService : OperationService, IOperationService
    {
        #region IOperationService Members

        public new CommerceResponse ProcessRequest(CommerceRequest request)
        {
            try
            {
                return base.ProcessRequest(request);
            }
            catch
            {
                Exception actualException;
                if (ActualFaultExceptionHandler.TryGetActualException(out actualException))
                    throw actualException;

                throw;
            }
        }

        #endregion
    }
}