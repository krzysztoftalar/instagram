﻿namespace Domain.Entities
{
    public class Photo
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }

        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}