namespace HouseBrokerMVP.Core.Model
{
    public class JwtConfig
    {
        public int ExpireDays { get; init; }
        public string Key { get; init; } = null!;
        public string Issuer { get; init; } = null!;
    }
}
