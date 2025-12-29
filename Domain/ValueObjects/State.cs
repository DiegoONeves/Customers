namespace Domain.ValueObjects
{
    public sealed record State
    {
        public string Value { get; }

        private static readonly HashSet<string> Valid =
        [
            "AC","AL","AP","AM","BA","CE","DF","ES","GO",
        "MA","MT","MS","MG","PA","PB","PR","PE","PI",
        "RJ","RN","RS","RO","RR","SC","SP","SE","TO"
        ];

        public State(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("State (UF) is required");

            var normalized = value.Trim().ToUpperInvariant();

            if (!Valid.Contains(normalized))
                throw new Exception($"Invalid UF: '{value}'");

            Value = normalized;
        }

        public override string ToString() => Value;
    }

}
