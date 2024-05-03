using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ReactionResponce
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ReactionBlog Like { get; set; }

        public ReactionResponce(bool success, string message, ReactionBlog like = null)
        {
            Success = success;
            Message = message;
            Like = like;
        }
    }
}
