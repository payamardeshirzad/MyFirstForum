using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstForum.Models
{
    public class PostModels
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        [DisplayName("UserName")]
        public string PosterName { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateSubmit { get; set; }

        public int CategoryId { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}