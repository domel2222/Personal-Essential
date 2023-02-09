namespace Application.UnitTests
{
    public static class AddMapsterForUnitTests
    {
        public static Mapper GetMapper()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(IRegister).Assembly);

            return new Mapper(config);
        }
    }
}
