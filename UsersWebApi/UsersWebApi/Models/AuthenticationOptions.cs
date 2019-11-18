namespace UsersWebApi.Models
{
    //Model for creating token
    public class AuthenticationOptions
    {
        public string JWTSecret { get; set; }
        public string ClientURL { get; set; }
    }
}
