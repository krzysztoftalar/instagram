﻿using Application.Services.User.Queries.CurrentUser;
using MediatR;

namespace Application.Services.User.Commands.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
