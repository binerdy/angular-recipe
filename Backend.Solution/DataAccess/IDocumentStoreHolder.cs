using Raven.Client.Documents;

namespace DataAccess
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore DocumentStore { get; }
    }
}