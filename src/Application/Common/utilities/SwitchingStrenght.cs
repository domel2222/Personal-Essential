namespace Application.Common.Utilities
{
    public static class UtilitiesStrenght
    {
        public const string Connectedness = "2A308E97-5314-4104-A0C6-77C6D56121F1";
        public const string Individualization = "3A19987B-2EDA-4645-91B5-B285B9113972";
        public const string Learner = "E4013A75-6D0C-40AA-BB38-B6FB69C95D20";
        public const string Focus = "D33453C3-C880-4C5D-A4E9-BC3C6CC2C9A5";
        public const string Achiever = "CF52FCFB-DF40-44DA-869F-BCAC271194D5";
        public const string SelfAssurance = "D571A099-78A6-4A3A-9128-C24D1DF7745A";
        public const string Futuristic = "103A482E-6E62-49E1-B2C9-C251E3955ED2";
        public const string Activator = "7C172324-0B15-4DB8-B77F-C9FF75B72218";
        public const string Responsibility = "AC23B6C8-8368-4F14-A11B-F0BC24CAF864";
        public const string Relator = "6C9EB440-49DE-4DB5-9B4E-FA21F261D20E";

        public static Guid SwitchStrenghtFromNameToGuid(string strenghtName) =>
            strenghtName switch
            {
                "Connectedness" => new Guid(Connectedness),
                "Individualization" => new Guid(Individualization),
                "Learner" => new Guid(Learner),
                "Focus" => new Guid(Focus),
                "Achiever" => new Guid(Achiever),
                "Self-Assurance" => new Guid(SelfAssurance),
                "Futuristic" => new Guid(Futuristic),
                "Activator" => new Guid(Activator),
                "Responsibility" => new Guid(Responsibility),
                "Relator" => new Guid(Relator),
                _ => Guid.Empty
            };

        public static string? SwitchStrenghtFromGuidToName(Guid strenghtId) =>
            strenghtId.ToString() switch
            {
                Connectedness => nameof(Connectedness),
                Individualization => nameof(Individualization),
                Learner => nameof(Focus),
                Focus => nameof(Focus),
                Achiever => nameof(Achiever),
                SelfAssurance => nameof(SelfAssurance),
                Futuristic => nameof(Futuristic),
                Activator => nameof(Activator),
                Responsibility => nameof(Responsibility),
                Relator => nameof(Relator),
                _ => default
            };
    }
}