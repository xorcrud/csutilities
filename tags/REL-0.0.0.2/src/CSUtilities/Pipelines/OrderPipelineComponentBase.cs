using System;
using Microsoft.CommerceServer.Interop;
using Microsoft.CommerceServer.Runtime;
using IDictionary = Microsoft.CommerceServer.Runtime.IDictionary;

namespace CSUtilities.Pipelines
{
    public abstract class OrderPipelineComponentBase : IPipelineComponent
    {
        public virtual int Execute(object pdispOrder, object pdispContext, int lFlags)
        {
            if (pdispOrder == null)
                throw new ArgumentNullException("pdispOrder");

            var order = pdispOrder as IDictionary;

            if (order == null)
                throw new InvalidOperationException(
                    String.Format("pdispOrder argument is not an IDictionary. Type is '{0}'", pdispOrder.GetType().FullName));

            return (int)Execute(order, pdispContext, lFlags);
        }

        protected virtual PipelineExecutionResult Execute(IDictionary order, object context, int flags)
        {
            try
            {
                Execute(new OrderAdapter(order));
                return PipelineExecutionResult.Success;
            }
            catch (Exception ex)
            {
                AddExceptionDetails(order, ex);
                return PipelineExecutionResult.Error;
            }
        }

        protected virtual void Execute(OrderAdapter order)
        {
        }

        protected virtual void AddExceptionDetails(IDictionary order, Exception ex)
        {
            if (order == null) throw new ArgumentNullException("order");
            if (ex == null) throw new ArgumentNullException("ex");

            object errorMessage = ex.Message;
            ((ISimpleList) order[OrderPipelineMappings.OrderForm.BasketErrors]).Add(ref errorMessage);
        }

        public virtual void EnableDesign(int fEnable)
        {
        }
    }
}