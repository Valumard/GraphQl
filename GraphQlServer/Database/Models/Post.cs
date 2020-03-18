using System;
using System.Collections.Generic;

namespace GraphQlServer.Database.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Header { get; set; }

        public string Content { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
