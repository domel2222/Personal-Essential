using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities
{
    public static class SwitchingStrenght
    {
        public static Guid SwitchStrenghtFromNameToGuid(string strenghtName) =>
            strenghtName switch
            {
                "Connectedness" => new Guid("2A308E97-5314-4104-A0C6-77C6D56121F1"),
                "Individualization" => new Guid("3A19987B-2EDA-4645-91B5-B285B9113972"),
                "Learner" => new Guid("E4013A75-6D0C-40AA-BB38-B6FB69C95D20"),
                "Focus" => new Guid("D33453C3-C880-4C5D-A4E9-BC3C6CC2C9A5"),
                "Achiever" => new Guid("CF52FCFB-DF40-44DA-869F-BCAC271194D5"),
                "Self-Assurance" => new Guid("D571A099-78A6-4A3A-9128-C24D1DF7745A"),
                "Futuristic" => new Guid("103A482E-6E62-49E1-B2C9-C251E3955ED2"),
                "Activator" => new Guid("7C172324-0B15-4DB8-B77F-C9FF75B72218"),
                "Responsibility" => new Guid("AC23B6C8-8368-4F14-A11B-F0BC24CAF864"),
                "Relator" => new Guid("6C9EB440-49DE-4DB5-9B4E-FA21F261D20E"),
                _ => throw new NotImplementedException()
            };
    }
}
