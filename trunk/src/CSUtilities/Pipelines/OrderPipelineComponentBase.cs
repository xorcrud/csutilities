using System;
using CSUtilities.Pipelines.OrderAdapters;
using Microsoft.CommerceServer.Interop;
using Microsoft.CommerceServer.Runtime;
using IDictionary = Microsoft.CommerceServer.Runtime.IDictionary;

namespace CSUtilities.Pipelines
{
    /// <summary>
    /// Base class for custom pipeline components. 
    /// This class will use the OrderAdapter types that abstracts "low-level" COM-based types used by the Pipeline System.
    /// </summary>
    public abstract class OrderPipelineComponentBase : IPipelineComponent
    {
        /// <summary>
        /// Default entry-method for execution Commerce Server Pipeline Components.
        /// </summary>
        /// <returns>1=Success,2=Warning,3=Error</returns>
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

        /// <summary>
        /// Wraps the pipeline execution in a try-catch clause.
        /// </summary>
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

        /// <summary>
        /// Is executed as part of the Pipeline Execution. Implement your logic here. 
        /// If any exceptions are thrown this will be catched by the Base Class and returned as a Pipeline Error containing the exception message.
        /// </summary>
        /// <param name="order">Instance of the executing Order using the OrderAdapter class.</param>
        protected abstract void Execute(OrderAdapter order);

        /// <summary>
        /// Adds any exception message to the Order instance within the _Basket_Errors collection.
        /// Override this class to implement custom logging of pipeline exceptions.
        /// </summary>
        protected virtual void AddExceptionDetails(IDictionary order, Exception ex)
        {
            if (order == null) throw new ArgumentNullException("order");
            if (ex == null) throw new ArgumentNullException("ex");

            AddBasketErrorMessage(order, ex.Message);
        }

        /// <summary>
        /// Adds a message to the Order instance within the _Basket_Errors collection.
        /// </summary>
        protected virtual void AddBasketErrorMessage(IDictionary order, string message)
        {
            object errorMessage = message;
            ((ISimpleList)order[OrderPipelineMappings.OrderForm.BasketErrors]).Add(ref errorMessage);
        }

        /// <summary>
        /// Required method by Commerce Server Pipeline System.
        /// Implemented as an empty method.
        /// </summary>
        /// <param name="fEnable"></param>
        public virtual void EnableDesign(int fEnable)
        {
        }
    }
}