using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OrderManager.Api.Application.Services;
using OrderManager.Api.Domain.AggregateModels.UserAggregate;
using System.Data;

namespace OrderManager.Api.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly ILogger<RegisterUserCommandHandler> _logger;
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public RegisterUserCommandHandler(
            ILogger<RegisterUserCommandHandler> logger,
            UserManager<User> userManager,
            ITokenService tokenService
            )
        {
            _logger = logger;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(
              new User { UserName = request.Username, Email = request.Email },
              request.Password!);

            if (result.Succeeded)
                return Result.Ok();

            var errors = result.Errors
               .Select(errors => new Error(errors.Description))
               .ToList();
            return Result.Fail(errors);
         }
    }
}
