namespace JWTGetToken.Services
{
    public interface ITokenService
    {
        public string GenerateToken(string username, string role);
    }
}
