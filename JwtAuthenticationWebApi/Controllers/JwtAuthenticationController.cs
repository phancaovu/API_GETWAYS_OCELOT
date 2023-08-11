using JwtAuthentication;
using JwtAuthentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthenticationController : ControllerBase
    {
        private readonly JwtTokenHandle _jwtauthentication;

        public JwtAuthenticationController(JwtTokenHandle jwtTokenHandler)
        {
            _jwtauthentication = jwtTokenHandler;
        }
        [HttpPost]
        public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var AuthenticationReponse = _jwtauthentication.GenerateJwtToken(request);
            if(AuthenticationReponse == null) {return Unauthorized();}
            return AuthenticationReponse;
        }




    }
}
