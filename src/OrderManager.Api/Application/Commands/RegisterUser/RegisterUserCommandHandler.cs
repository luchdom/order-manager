using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;
using OrderManager.Api.Application.Services;
using OrderManager.Api.Domain.AggregateModels.UserAggregate;
using System.Data;

namespace OrderManager.Api.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<int>>
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
        public async Task<Result<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return Result.Ok(user.Id);

            
            var errors = result.Errors
               .Select(errors => new Error(errors.Description))
               .ToList();
            _logger.LogDebug("User with email {Email} could not be registered due to {@Errors}", request.Email, errors);
            return Result.Fail(errors);
         }
    }
}
