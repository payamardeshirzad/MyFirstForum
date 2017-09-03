using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstForum.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerTopic { get; set; }
        public string AnswerBody { get; set; }
        public string AnswerSender { get; set; }
        public int PosModelsId { get; set; }
        
    }
}