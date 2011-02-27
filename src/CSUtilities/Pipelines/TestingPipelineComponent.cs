using System.Runtime.InteropServices;
using Microsoft.CommerceServer.Runtime;

namespace CSUtilities.Pipelines
{
    [Guid("34104807-4B22-40A4-89AA-4686D092BE29")]
    [ComVisible(true)]
    public class TestingPipelineComponent : OrderPipelineComponentBase
    {
        protected override void Execute(OrderAdapter order)
        {
            //
        }
    }
}