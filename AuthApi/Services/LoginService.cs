using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            return await db.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }

}
