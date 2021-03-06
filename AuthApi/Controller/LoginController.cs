using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestStore.AuthApi.Entities;
using TestStore.AuthApi.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestStore.AuthApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        readonly LoginService loginService;

        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] User reqUser)
        {
            var user = await loginService.AuthenticateAsync(reqUser.Email, reqUser.Password);

            if (user != null)
            {
                AuthResponse response = new AuthResponse()
                {
                    AccessToken = "itsaccesstoken",
                    User = user
                };

                return response;
            }

            return Unauthorized();
        }

       
    }
}
