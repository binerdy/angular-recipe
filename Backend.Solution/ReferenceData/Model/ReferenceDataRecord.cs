namespace ReferenceData.Model
{
    public record ReferenceDataRecord : AbstractDocument
    {
        public required string Key { get; set; } = string.Empty;

        public required string DisplayName { get; set; } = string.Empty;

        public required ReferenceDataType ReferenceDataType { get; set; } = ReferenceDataType.None;

        public Dictionary<string, string> Properties { get; set; } = [];

        public required DateOnly ValidFrom { get; set; }

        public required DateOnly ValidTo { get; set; }

        protected override string CreateId() => $"{ReferenceDataType}/{Key}";
    }
}
