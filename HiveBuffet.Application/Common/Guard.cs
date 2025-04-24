using HiveBuffet.Domain.Exceptions;

namespace HiveBuffet.Application.Common;

public static class Guard
{
    public static void ThrowIfNull(object? obj, string identifier, string objectName)
    {
        if (obj is null)
        {
            throw new NotFoundException($"{objectName} with id: {identifier} not found.");
        }
    }
}
