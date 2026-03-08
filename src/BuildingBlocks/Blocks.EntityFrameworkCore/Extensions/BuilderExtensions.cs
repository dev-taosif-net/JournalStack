using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blocks.EntityFrameworkCore.Extensions;

public static class BuilderExtensions
{
    //.HasConversion<string>() is Used to convert an enum property to a string representation in the database.
    //This allows you to store the enum values as strings instead of their underlying integer values,
    //making the data more readable and easier to understand when querying the database directly.
    public static PropertyBuilder<TEnum> HasEnumConversion<TEnum>(this PropertyBuilder<TEnum> builder,
        int maxLength = 64)
        where TEnum : Enum
    {
        return builder
            .HasConversion(
                e => e.ToString(),
                value => (TEnum)Enum.Parse(typeof(TEnum), value))
            .HasMaxLength(maxLength);
    }
    
}