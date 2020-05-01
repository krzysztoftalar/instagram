﻿using System.Collections.Generic;
using Application.Services.Profiles;
using MediatR;

namespace Application.Services.Followers.Queries.List
{
    public class FollowersListQuery : IRequest<List<ProfileDto>>
    {
        public string Username { get; set; }
        public string Predicate { get; set; }
    }
}
