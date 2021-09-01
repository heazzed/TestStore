using System;


namespace TestStore.AuthApi.Entities
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }

        public User User { get; set; }
    }
}
