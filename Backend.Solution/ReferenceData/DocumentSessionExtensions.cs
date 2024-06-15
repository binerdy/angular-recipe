using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Session;
using System.Security.Principal;

namespace ReferenceData
{
    public static class DocumentSessionExtensions
    {
        public static Task<IEnumerable<T>> LoadPrefix<T>(this IAsyncDocumentSession session)
            where T : AbstractDocument
        {
            return session.Advanced.LoadStartingWithAsync<T>($"{DocumentConventions.DefaultGetCollectionName(typeof(T))}");
        }

        public static async Task<T> StoreNewRevision<T>(this IAsyncDocumentSession session, T document) where T : AbstractDocument
        {
            var username = OperatingSystem.IsWindows() ? WindowsIdentity.GetCurrent().Name : Environment.UserName;

            document.Revision = DateTime.UtcNow;
            document.RevisionBy = username;
            await session.StoreAsync(document);

            return document;
        }

        public static T[] LoadPrefix<T>(this IDocumentSession session)
            where T : AbstractDocument
        {
            return session.Advanced.LoadStartingWith<T>($"{DocumentConventions.DefaultGetCollectionName(typeof(T))}");
        }

        public static T StoreNewRevisionAsync<T>(this IDocumentSession session, T document) where T : AbstractDocument
        {
            var username = OperatingSystem.IsWindows() ? WindowsIdentity.GetCurrent().Name : Environment.UserName;

            document.Revision = DateTime.UtcNow;
            document.RevisionBy = username;
            session.Store(document);

            return document;
        }
    }
}
