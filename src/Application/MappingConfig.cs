namespace Application
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<MostWinDuringTheDay, MostWinDuringTheDayResponse>()
                .Map(dest => dest.StrenghtName, src => SwitchingStrenght.SwitchStrenghtFromGuidToName(src.StrenghtId));         
        }
    }
}
