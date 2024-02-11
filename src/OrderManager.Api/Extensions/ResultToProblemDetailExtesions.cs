using Microsoft.AspNetCore.Mvc;

namespace OrderManager.Api.Extensions;

public static class ResultToProblemDetailExtesions
{
    public static ProblemDetails ToProblemDetails<T>(this Results<T> result)
    {
        ProblemDetails problemDetails = new ProblemDetails();
        problemDetails.Status = StatusCodes.Status400BadRequest;
        problemDetails.Title = "One or more validation errors occurred.";
        problemDetails.Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";

        problemDetails.Detail = new MultipleError
    }
}
