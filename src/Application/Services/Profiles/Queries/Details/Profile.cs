﻿using System.Collections.Generic;
using Domain.Entities;

namespace Application.Services.Profiles.Queries.Details
{
    public class Profile
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public bool Following { get; set; }
        public int FollowingCount { get; set; }
        public int FollowersCount { get; set; }
    }
}
