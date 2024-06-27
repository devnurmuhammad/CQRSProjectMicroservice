namespace TurarJoy.Application.CashingService
{
    public interface ITokenService
    {
        public string GenerateToken(string username, string role);
    }
}
