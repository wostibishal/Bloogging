using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ReactionCommentResponce
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ReactionComment Likecmt { get; set; }

        public ReactionCommentResponce(bool success, string message, ReactionComment like = null)
        {
            Success = success;
            Message = message;
            Likecmt = like;
        }
    }
}
