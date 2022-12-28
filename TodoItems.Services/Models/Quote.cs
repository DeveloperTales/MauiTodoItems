﻿namespace TodoItems.Services.Models
{
    public class Quote
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } 
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}