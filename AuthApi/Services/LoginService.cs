using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TestStore.AuthApi.Entities;
using TestStore.AuthApi.Models;

namespace TestStore.AuthApi.Services
{
    public class LoginService
    {
        readonly StoreContext db;

        public LoginService(StoreContext db)
        {
            this.db = db;
        }

        public User Authenticate(string email, string password)
        {
            return db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

    //using StreamReader reader = new StreamReader(httpRequest.Body);

    //var body = await reader.ReadToEndAsync();

    //User user = JsonConvert.DeserializeObject<User>(body);
}

}
