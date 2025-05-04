namespace mymoney.Models.Common;

public sealed class Email
{
    private Email() { } // Required by EF Core

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; private set; } = string.Empty;

    public static Email? Create(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return null;

        // Basic email validation
        if (!email.Contains('@') || !email.Contains('.'))
            throw new ArgumentException("Invalid email format", nameof(email));

        return new Email(email.Trim().ToLowerInvariant());
    }

    public override string ToString() => Value;

    public static implicit operator string(Email email) => email.Value;
}