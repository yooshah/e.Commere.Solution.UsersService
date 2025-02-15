
namespace e.Commerce.Core.DTO;

public record RegisterRequest(
string? Email,
string? Password,
string? PersonName,
GenderOptions Gender);
