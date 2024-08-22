namespace Restaurant.Application.Contracts;

public record LoginResponse(bool Flag, string Message = null!, string Token = null!);