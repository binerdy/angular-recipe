using Raven.Client.Documents.Conventions;

namespace ReferenceData
{
    public abstract record AbstractDocument
    {
        public string Id => $"{DocumentConventions.DefaultGetCollectionName(GetType())}/{this.CreateId()}";

        public DateTime Revision { get; set; } = DateTime.Now;

        public string RevisionBy { get; set; } = string.Empty;

        protected abstract string CreateId();
    }
}
