namespace ELearning.Common
{
    public class AuthData
    {
        public string Token { get; set; }
        public long TokenExpirationTime { get; set; }
        public string Id { get; set; }
        public string Role { get; set; }
    }
}
