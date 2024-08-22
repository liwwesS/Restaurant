namespace Restaurant.Application.Contracts;

public record AuthenticationResponse(
    bool Success,
    string Message,
    Guid? UserId = default!,
    string? Token = default!,
    string? UserName = default!,
    string? Email = default!
);