using e.Commerce.Core.DTO;
using e.Commerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e.Commere.Solution.UsersService.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IUsersService _usersService;

    public AuthController( IUsersService usersService)
    {
        _usersService = usersService;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        //Check for invalid registerRequest
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration data");
        }

        //Call the UsersService to handle registration
        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest(authenticationResponse);
        }

        return Ok(authenticationResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        //Check for invalid LoginRequest
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return Unauthorized(authenticationResponse);
        }

        return Ok(authenticationResponse);
    } 


}
