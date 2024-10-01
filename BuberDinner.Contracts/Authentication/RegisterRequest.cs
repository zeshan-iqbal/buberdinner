namespace BuberDinner.Contracts.Authentication;

public record RegisterReuest(string FirstName, string LastName, string Email, string Password);