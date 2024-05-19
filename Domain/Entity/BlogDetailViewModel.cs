using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class BlogDetailViewModel
    {
        public Blogging Blog { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
