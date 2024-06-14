namespace ReferenceData.Host
{
    public record ReferenceDataRecord
    {
        public string Key { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public string ReferenceDataType { get; set; } = string.Empty;

        public Dictionary<string, string> Properties { get; set; } = [];

        public DateOnly ValidFrom { get; set; }

        public DateOnly ValidTo { get; set; }
    }
}
