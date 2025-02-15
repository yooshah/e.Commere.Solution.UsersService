

using e.Commerce.Core.DTO;

namespace e.Commerce.Core.ServiceContracts;

public interface IUsersService
{

    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
