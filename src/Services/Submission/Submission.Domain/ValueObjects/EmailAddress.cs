using System.Net.Mail;
using System.Text.RegularExpressions;
using Blocks.Core;

namespace Submission.Domain.ValueObjects;

public class EmailAddress
{
    private string Value { get; set; }
    private EmailAddress(string value) => Value = value;

    public static EmailAddress Create(string value)
    {
        Guard.ThrowIfNullOrWhiteSpace(value);
        return !IsValidEmail(value) ? throw new ArgumentException($"'{value}' is not a valid email address.") : new EmailAddress(value.ToLower());
    }
    
    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        const string basicPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, basicPattern, RegexOptions.IgnoreCase))
            return false;
        try
        {
            var addr = new MailAddress(email);
            return addr.Address.Equals(email, StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }
}