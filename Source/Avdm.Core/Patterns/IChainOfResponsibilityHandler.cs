namespace Avdm.Core.Patterns
{
    public interface IChainOfResponsibilityHandler<in TClient, in TData>
        where TClient : class
    {
        bool Handle( TClient client, TData data, bool wasHandled );
    }

    public abstract class ChainOfResponsibilityHandler<TClient, TData> : IChainOfResponsibilityHandler<TClient, TData> where TClient : class
    {
        public bool Handle( TClient client, TData data, bool wasHandled )
        {
            return false;
        }
    }
}
