using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OrderManager.Api.Application.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<Result>
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
