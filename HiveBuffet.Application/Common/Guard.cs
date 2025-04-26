using HiveBuffet.Domain.Exceptions;

namespace HiveBuffet.Application.Common;

public static class Guard
{
    public static void ThrowIfNull(object? obj, string identifier, string objectName)
    {
        if (obj == null)
        {
            throw new NotFoundException($"{objectName} with identifier: {identifier} not found.");
        }
    }

    public static void ThrowIfNull(object? obj, string objectName)
    {
        if (obj == null)
        {
            throw new NotFoundException($"{objectName} not found.");
        }
    }
}
