using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FirstForum.Models
{
    public class PostDBContext: DbContext
    {
        public DbSet<CategoryTopic> CategoryTopics { get; set; }
        public DbSet<PostModels> Posts { get; set; }
        public DbSet<Answer> Answers { get; set; } 
        public DbSet<UserProfile> UserProfiles { get; set; } 
    }
}