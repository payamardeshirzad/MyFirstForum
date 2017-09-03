using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstForum.Models
{
    public class CategoryTopic
    {
        public int Id  { get; set; }
        public string CatName { get; set; }
        public virtual ICollection<PostModels> PostModelses { get; set; } 
    }
}