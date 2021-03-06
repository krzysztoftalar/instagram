﻿using Application.Errors;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Application.Services.User.Commands.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand>
    {
        private readonly UserManager<AppUser> _userManager;

        public VerifyEmailCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.NotFound, new { User = "Not Found" });
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.EmailToken);

            if (result.Succeeded) return Unit.Value;

            throw new RestException(HttpStatusCode.BadRequest, new { Email = "Invalid email verification token." });
        }
    }
}