using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusCodeFactory
{
    public static StatusCode? Create(StatusCodeRegistrationForm form) => form == null ? null : new()
    {
        StatusName = form.StatusName,
    };

    public static StatusCode? Create(StatusEntity entity)
    {
        if (entity == null)
            return null;
        var statusCode = new StatusCode()
        {
            Id = entity.Id,
            StatusName = entity.StatusName,
        };
        return statusCode;
    }
}

